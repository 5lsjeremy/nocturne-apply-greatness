using System.Numerics;
using PrismX.Shared.Types.Builders;
using PrismX.Shared.Types.Clusters;
using PrismX.Shared.Types.Context;
using PrismX.Shared.Types.Contracts.Context;
using PrismX.Shared.Types.Contracts.States;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Clusters;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Context;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Engines;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain
{
    public sealed class StudentAnalyzeVectorBuilder : IResolvedVectorBuilder<StudentAnalyzeAction>
    {
        private readonly IMasteryDriftEngine _driftEngine;
        private readonly IDifficultyDriftScalingEngine _difficultyScaler;
        private readonly IMasteryProgressionEngine _progressionEngine;
        private readonly IMasteryThresholdEngine _thresholdEngine;

        public StudentAnalyzeVectorBuilder(
            IMasteryDriftEngine driftEngine,
            IDifficultyDriftScalingEngine difficultyScaler,
            IMasteryProgressionEngine progressionEngine,
            IMasteryThresholdEngine thresholdEngine)
        {
            _driftEngine = driftEngine;
            _difficultyScaler = difficultyScaler;
            _progressionEngine = progressionEngine;
            _thresholdEngine = thresholdEngine;
        }

        public IResolvedVectorContext Build(
            object domainInput,
            IActionDefinition actionDefinition,
            ITimeState timeState,
            IRandomState randomState,
            ISimulationState simulationState)
        {
            var input = (StudentAnalyzeInput)domainInput;

            var ctx = new StudentAnalyzeResolvedVectorContext(
                actionDefinition,
                timeState,
                randomState,
                simulationState);

            // ---------------------------------------------------------
            // 1. Normalize metadata
            // ---------------------------------------------------------
            var cognitiveRaw     = CognitiveDimensionMapper.Map(input);
            var affectiveRaw     = AffectiveDimensionMapper.Map(input);
            var difficultyRaw    = DifficultyEstimator.Estimate(input.AssignmentText);
            var disability       = DisabilityProfileMapper.Map(input);
            var misconceptionRaw = MisconceptionMapper.Map(input);

            var cognitive     = DomainNormalization.NormalizeCognitive(cognitiveRaw);
            var affective     = DomainNormalization.NormalizeAffective(affectiveRaw);
            var difficulty    = DomainNormalization.NormalizeDifficulty(difficultyRaw);
            var misconception = DomainNormalization.NormalizeMisconception(misconceptionRaw);

            ctx.ClusterMetadata["unitSlug"]        = input.UnitSlug;
            ctx.ClusterMetadata["assignmentText"]  = input.AssignmentText;
            ctx.ClusterMetadata["studentResponse"] = input.StudentResponse;

            ctx.ClusterMetadata["cognitive"]       = cognitive;
            ctx.ClusterMetadata["affective"]       = affective;
            ctx.ClusterMetadata["difficulty"]      = difficulty;
            ctx.ClusterMetadata["disability"]      = disability;
            ctx.ClusterMetadata["misconception"]   = misconception;

            var tags = StudentClusterTags.Extract(input);
            ctx.ClusterMetadata["tags"] = tags;

            // ---------------------------------------------------------
            // 2. Load previous mastery
            // ---------------------------------------------------------
            var lastCluster = simulationState.Clusters.LastOrDefault();
            float previousMastery = 0f;

            if (lastCluster != null &&
                lastCluster.Metadata.TryGetValue("masteryScore", out var prevObj) &&
                prevObj is float prevFloat)
            {
                previousMastery = prevFloat;
            }

            // ---------------------------------------------------------
            // 3. Build domain state
            // ---------------------------------------------------------
            var domainState = new StudentAssignmentState
            {
                LastCognitiveDimension = cognitive,
                LastAffectiveDimension = affective,
                LastAssignmentDifficulty = difficulty,
                LastDisabilityProfile = disability,
                MasteryScore = previousMastery
            };

            if (misconception != "none")
                domainState.ActiveMisconceptions.Add(misconception);

            // ---------------------------------------------------------
            // 4. Drift + progression
            // ---------------------------------------------------------
            var driftCtx = new MasteryDriftContext(
                ctx,
                lastCluster ?? new EmptyCluster(),
                new StudentState
                {
                    LastCognitiveDimension = cognitive,
                    LastAffectiveDimension = affective,
                    LastAssignmentDifficulty = difficulty
                },
                Slug.BuildSkillUnitFromSlug(input.UnitSlug),
                domainState);

            var drift = _driftEngine.ComputeDrift(driftCtx);
            var scaledDrift = _difficultyScaler.Scale(drift, difficulty);
            var progression = _progressionEngine.ComputeProgression(driftCtx);

            domainState.MasteryScore += scaledDrift + progression;
            domainState.MasteryScore = Math.Clamp(domainState.MasteryScore, 0f, 1f);

            domainState.MasteryCategory = _thresholdEngine.Evaluate(domainState.MasteryScore);

            ctx.ClusterMetadata["masteryScore"]    = domainState.MasteryScore;
            ctx.ClusterMetadata["masteryCategory"] = domainState.MasteryCategory;

            // ---------------------------------------------------------
            // 5. PRISM vector physics
            // ---------------------------------------------------------
            ctx.CurrentDirection  = Vector3.UnitY;
            ctx.CurrentMagnitude  = domainState.MasteryScore;
            ctx.CurrentConfidence = 0.9f;
            ctx.CurrentStability  = 0.8f;
            ctx.CurrentVariance   = 0.1f;

            // ---------------------------------------------------------
            // 6. MANUALLY create a cluster (required for your SDK)
            // ---------------------------------------------------------
            var newCluster = new StudentCluster(
                centroid: ctx.CurrentDirection ?? Vector3.Zero,
                confidence: ctx.CurrentConfidence ?? 0,
                stability: ctx.CurrentStability ?? 0,
                variance: ctx.CurrentVariance ?? 0,
                polarity: 1f,
                tags: tags,
                metadata: new Dictionary<string, object>(ctx.ClusterMetadata));

            simulationState.Clusters = simulationState.Clusters
                .Concat(new[] { newCluster })
                .ToList();
            
            return ctx;
        }

        private sealed record EmptyCluster : ClusterBase { }
    }
}