using PrismX.Shared.Types.Contracts.Base.Context;
using PrismX.Shared.Types.Contracts.Context;
using PrismX.Shared.Types.Contracts.Engines;
using PrismX.Shared.Types.Contracts.States;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Data;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Records;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain;

public sealed class StudentSimulationRunner
{
    private readonly IEngineBase _engine;
    private readonly IActionDefinition _actionDefinition;
    private readonly ITimeState _time;
    private readonly IRandomState _random;
    private readonly ISimulationState _sim;
    private readonly StudentProfile _profile;
    private readonly StudentState _state;

    private readonly IMasteryDriftEngine _driftEngine;

    public StudentSimulationRunner(
        IEngineBase engine,
        IActionDefinition actionDefinition,
        ITimeState time,
        IRandomState random,
        ISimulationState sim,
        StudentProfile profile,
        StudentState state,
        IMasteryDriftEngine driftEngine)
    {
        _engine = engine;
        _actionDefinition = actionDefinition;
        _time = time;
        _random = random;
        _sim = sim;
        _profile = profile;
        _state = state;
        _driftEngine = driftEngine;
    }


    public async Task<StudentSimulationResult> RunAsync(
        StudentAnalyzeInput input,
        CancellationToken cancellationToken = default)
    {
        var prismResult = await _engine.HandleAsync<StudentAnalyzeAction>(
            _actionDefinition,
            _time,
            _random,
            _sim,
            input);

        if (prismResult.Context is not IPrismContext ctx)
            throw new InvalidOperationException("PRISM returned no context.");

        if (ctx.Clusters.Count == 0)
            throw new InvalidOperationException("PRISM returned no clusters.");

        var cluster = ctx.Clusters[0];

        // Update student state from physics
        _state.CurrentConfidence  = cluster.Confidence;
        _state.CurrentAttention   = cluster.Stability;
        _state.CurrentFrustration = cluster.Variance;

        // Merge static + dynamic tags
        var tags = new List<string>(cluster.Tags);

        if (cluster.Metadata.TryGetValue("tags", out var tagObj) &&
            tagObj is IEnumerable<string> dynamicTags)
        {
            tags.AddRange(dynamicTags);
        }

        // Apply tag projections (misconceptions, cognitive, affective, etc.)
        ApplyTagProjections(tags);

        // Apply mastery drift
        var unit = FindUnit(input.UnitSlug);
        if (unit != null)
        {
            var drift = _driftEngine.ComputeDrift(new MasteryDriftContext
            {
                Cluster = cluster,
                State = _state,
                Unit = unit
            });

            unit.Score = Math.Clamp(unit.Score + drift, 0, 100);
        }
        
        return new StudentSimulationResult
        {
            PrismResult  = prismResult,
            UpdatedState = _state,
            Cluster      = cluster
        };
    }

    private void ApplyTagProjections(IEnumerable<string> tags)
    {
        foreach (var tag in tags)
        {
            foreach (var rule in StudentTagProjections.Rules)
            {
                if (tag.StartsWith(rule.Key, StringComparison.OrdinalIgnoreCase))
                {
                    var value = tag.Substring(rule.Key.Length);
                    rule.Value(_state, value);
                }
            }
        }
    }

    private SkillUnit? FindUnit(string slug)
    {
        foreach (var subject in _profile.Subjects.Values)
        {
            foreach (var course in subject.Courses.Values)
            {
                foreach (var unit in course.Units.Values)
                {
                    if (unit.UnitSlug == slug)
                        return unit;
                }
            }
        }
        return null;
    }
}