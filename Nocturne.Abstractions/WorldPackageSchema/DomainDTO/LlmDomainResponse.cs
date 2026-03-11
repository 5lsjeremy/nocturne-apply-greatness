using System.Text.Json.Serialization;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;

namespace Nocturne.Abstractions.WorldPackageSchema.DomainDTO
{
    public sealed record LlmDomainResponse
    {
        public string DomainName { get; init; } = string.Empty;
        public string Summary { get; init; } = string.Empty;

        public List<string> Boundaries { get; init; } = new();
        public string Tone { get; init; } = string.Empty;
        public List<string> Tags { get; init; } = new();

        public List<string> Opportunities { get; init; } = new();
        public List<string> Risks { get; init; } = new();
        public List<string> DriftWarnings { get; init; } = new();

        public List<string> PressureTestSeeds { get; init; } = new();
        public List<string> PrismSeeds { get; init; } = new();

        public int ClarityScore { get; init; }
        public ClaritySection Good { get; init; } = new();
        public ClaritySection Bad { get; init; } = new();
        public ClaritySection Ugly { get; init; } = new();
        public string ClarityNotes { get; init; } = string.Empty;

        public string CreativePotential { get; init; } = string.Empty;
        public List<string> ProductionRisks { get; init; } = new();
        public List<string> OpportunitiesFeasibility { get; init; } = new();
        public List<string> Pitfalls { get; init; } = new();
        public string AlignmentWithWorld { get; init; } = string.Empty;
        public string ExpectedComplexity { get; init; } = string.Empty;
        public List<string> RecommendedFocusAreas { get; init; } = new();
    }
}