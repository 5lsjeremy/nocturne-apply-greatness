using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Builders
{
    internal sealed class ConceptBuilder:IConceptBuilder
    {
        private readonly string _worldConcept;
        private readonly SurfaceLogger _logger = new();

        public string WorldConcept => _worldConcept;
        public bool? IsClear { get; private set; }
        IReadOnlyList<string> IConceptBuilder.ClarityRecommendations => ClarityRecommendations;

        IReadOnlyList<string> IConceptBuilder.ClarityQuestions => ClarityQuestions;

        public List<string> ClarityRecommendations { get; } = new();
        public List<string> ClarityQuestions { get; } = new();

        public string? Pitch { get; private set; }
        IReadOnlyList<string> IConceptBuilder.PitchRecommendations => PitchRecommendations;

        public List<string> PitchRecommendations { get; } = new();

        public IOverlayTags? Tags { get; private set; }
        IReadOnlyList<string> IConceptBuilder.TagRecommendations => TagRecommendations;

        public List<string> TagRecommendations { get; } = new();

        public bool IsFeasible { get; private set; } = true;
        public string? FailureReason { get; private set; }
        public void SetClarity(bool isClear, IReadOnlyList<string> recommendations, IReadOnlyList<string> questions)
        {
            throw new NotImplementedException();
        }

        public void SetPitch(string? pitch, IReadOnlyList<string> recommendations)
        {
            throw new NotImplementedException();
        }

        public void SetTags(IOverlayTags? tags, IReadOnlyList<string> recommendations)
        {
            throw new NotImplementedException();
        }

        public SurfaceLogger Logger => _logger;

        public ConceptBuilder(string worldConcept)
        {
            _worldConcept = worldConcept;
            _logger.Info($"ConceptBuilder created for concept: '{worldConcept}'.");
        }

        // Called by LLM adapter
        public void SetClarity(bool? isClear, IEnumerable<string> recs, IEnumerable<string> questions)
        {
            IsClear = isClear;
            ClarityRecommendations.AddRange(recs);
            ClarityQuestions.AddRange(questions);

            if (isClear == true)
                _logger.Info("Clarity evaluation succeeded.");
            else if (isClear == false)
                _logger.Warn("Clarity evaluation indicates the concept is unclear.");
            else
                _logger.Warn("Clarity evaluation returned null.");
        }

        public void SetPitch(string? pitch, IEnumerable<string> recs)
        {
            Pitch = pitch;
            PitchRecommendations.AddRange(recs);

            if (pitch != null)
                _logger.Info("Pitch generated successfully.");
            else
                _logger.Error("Pitch generation failed.");
        }

        public void SetTags(IOverlayTags? tags, IEnumerable<string> recs)
        {
            Tags = tags;
            TagRecommendations.AddRange(recs);

            if (tags != null)
                _logger.Info("Tags inferred successfully.");
            else
                _logger.Error("Tag inference failed.");
        }

        public void MarkFailure(string reason)
        {
            IsFeasible = false;
            FailureReason = reason;
            _logger.Error($"Concept marked as failed: {reason}");
        }

        public void MarkSuccess()
        {
            IsFeasible = true;
            _logger.Info("Concept evaluation marked as successful.");
        }

        public IConcept Build()
        {
            _logger.Info("Building final concept artifact.");

            return new Concept(
                worldConcept: _worldConcept,
                isClear: IsClear,
                clarityRecs: ClarityRecommendations,
                clarityQuestions: ClarityQuestions,
                pitch: Pitch,
                pitchRecs: PitchRecommendations,
                tags: Tags,
                tagRecs: TagRecommendations,
                isFeasible: IsFeasible,
                failureReason: FailureReason,
                logs: _logger.Entries.ToList()
            );
        }

        private sealed class Concept : IConcept
        {
            public string WorldConcept { get; }
            public bool? IsClear { get; }
            public IReadOnlyList<string> ClarityRecommendations { get; }
            public IReadOnlyList<string> ClarityQuestions { get; }

            public string? Pitch { get; }
            public IReadOnlyList<string> PitchRecommendations { get; }

            public IOverlayTags? Tags { get; }
            public IReadOnlyList<string> TagRecommendations { get; }

            public bool IsFeasible { get; }
            public string? FailureReason { get; }

            public IReadOnlyCollection<ISurfaceLogEntry> Logs { get; }

            public Concept(
                string worldConcept,
                bool? isClear,
                IReadOnlyList<string> clarityRecs,
                IReadOnlyList<string> clarityQuestions,
                string? pitch,
                IReadOnlyList<string> pitchRecs,
                IOverlayTags? tags,
                IReadOnlyList<string> tagRecs,
                bool isFeasible,
                string? failureReason,
                IReadOnlyCollection<ISurfaceLogEntry> logs)
            {
                WorldConcept = worldConcept;
                IsClear = isClear;
                ClarityRecommendations = clarityRecs;
                ClarityQuestions = clarityQuestions;
                Pitch = pitch;
                PitchRecommendations = pitchRecs;
                Tags = tags;
                TagRecommendations = tagRecs;
                IsFeasible = isFeasible;
                FailureReason = failureReason;
                Logs = logs;
            }
        }
    }
}