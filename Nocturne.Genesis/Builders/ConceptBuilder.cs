using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Surface;
using Nocturne.Genesis.Concepts;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Builders
{
    internal sealed class ConceptBuilder : IConceptBuilder
    {
        private readonly string _worldConcept;
        private readonly SurfaceLogger _logger = new();

        public string WorldConcept => _worldConcept;

        public bool? IsClear { get; private set; }

        public List<string> ClarityRecommendations { get; } = new();
        public List<string> ClarityQuestions { get; } = new();

        IReadOnlyList<string> IConceptBuilder.ClarityRecommendations => ClarityRecommendations;
        IReadOnlyList<string> IConceptBuilder.ClarityQuestions => ClarityQuestions;

        public string? Pitch { get; private set; }
        public List<string> PitchRecommendations { get; } = new();
        IReadOnlyList<string> IConceptBuilder.PitchRecommendations => PitchRecommendations;

        public IOverlayTags? Tags { get; private set; }
        public List<string> TagRecommendations { get; } = new();
        IReadOnlyList<string> IConceptBuilder.TagRecommendations => TagRecommendations;

        public bool IsFeasible { get; private set; } = true;
        public string? FailureReason { get; private set; }

        public SurfaceLogger Logger => _logger;

        public ConceptBuilder(string worldConcept)
        {
            _worldConcept = worldConcept;
            _logger.Info($"ConceptBuilder created for concept: '{worldConcept}'.");
        }

        // ---------------------------------------------------------------------
        // INTERFACE IMPLEMENTATIONS
        // ---------------------------------------------------------------------

        public void SetClarity(bool isClear, IReadOnlyList<string> recommendations, IReadOnlyList<string> questions)
        {
            SetClarity((bool?)isClear, recommendations, questions);
        }

        public void SetPitch(string? pitch, IReadOnlyList<string> recommendations)
        {
            SetPitch(pitch, (IEnumerable<string>)recommendations);
        }

        public void SetTags(IOverlayTags? tags, IReadOnlyList<string> recommendations)
        {
            SetTags(tags, (IEnumerable<string>)recommendations);
        }

        // ---------------------------------------------------------------------
        // INTERNAL WORKING IMPLEMENTATIONS
        // ---------------------------------------------------------------------

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

        // ---------------------------------------------------------------------
        // FEASIBILITY MARKERS
        // ---------------------------------------------------------------------

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

        // ---------------------------------------------------------------------
        // FINAL ARTIFACT
        // ---------------------------------------------------------------------

        public IConcept Build()
        {
            _logger.Info("Building final concept artifact.");

            var metadata = new ConceptMetadata();
            foreach (var entry in _logger.Entries)
                metadata.AddLog(entry);

            var concept = new ConceptBase
            {
                Core = new ConceptCore
                {
                    WorldConcept = _worldConcept,
                    Pitch = Pitch
                },

                Evaluation = new ConceptEvaluation
                {
                    IsClear = IsClear,
                    ClarityRecommendations = ClarityRecommendations.ToList(),
                    ClarityQuestions = ClarityQuestions.ToList(),

                    PitchRecommendations = PitchRecommendations.ToList(),
                    TagRecommendations = TagRecommendations.ToList(),

                    IsFeasible = IsFeasible,
                    FailureReason = FailureReason
                },

                Extraction = new ConceptExtraction
                {
                    Tags = Tags
                },

                Metadata = metadata
            };

            return concept;
        }
    }
}