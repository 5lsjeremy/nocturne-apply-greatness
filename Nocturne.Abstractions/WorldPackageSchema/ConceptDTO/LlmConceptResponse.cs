using System.Text.Json.Serialization;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed record LlmConceptResponse
    {
        // -----------------------------
        // CORE CONCEPT
        // -----------------------------
        [JsonPropertyName("worldName")]
        public string WorldName { get; init; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; init; } = string.Empty;

        [JsonPropertyName("themes")]
        public List<string> Themes { get; init; } = new();

        [JsonPropertyName("coreFantasy")]
        public string CoreFantasy { get; init; } = string.Empty;

        [JsonPropertyName("tone")]
        public string Tone { get; init; } = string.Empty;

        [JsonPropertyName("genre")]
        public string Genre { get; init; } = string.Empty;

        [JsonPropertyName("setting")]
        public string Setting { get; init; } = string.Empty;

        [JsonPropertyName("playerFantasy")]
        public string PlayerFantasy { get; init; } = string.Empty;

        [JsonPropertyName("creativeNorthStar")]
        public string CreativeNorthStar { get; init; } = string.Empty;

        [JsonPropertyName("seedId")]
        public string SeedId { get; init; } = string.Empty;

        // -----------------------------
        // CLARITY
        // -----------------------------
        [JsonPropertyName("clarityScore")]
        public int ClarityScore { get; init; }

        [JsonPropertyName("good")]
        public ClaritySection Good { get; init; } = new();

        [JsonPropertyName("bad")]
        public ClaritySection Bad { get; init; } = new();

        [JsonPropertyName("ugly")]
        public ClaritySection Ugly { get; init; } = new();

        [JsonPropertyName("clarityNotes")]
        public string ClarityNotes { get; init; } = string.Empty;

        // -----------------------------
        // PITCH
        // -----------------------------
        [JsonPropertyName("tagline")]
        public string Tagline { get; init; } = string.Empty;

        [JsonPropertyName("oneSentencePitch")]
        public string OneSentencePitch { get; init; } = string.Empty;

        [JsonPropertyName("thirtySecondPitch")]
        public string ThirtySecondPitch { get; init; } = string.Empty;

        [JsonPropertyName("marketPosition")]
        public string MarketPosition { get; init; } = string.Empty;

        [JsonPropertyName("emotionalHook")]
        public string EmotionalHook { get; init; } = string.Empty;

        [JsonPropertyName("playerPromise")]
        public string PlayerPromise { get; init; } = string.Empty;

        // -----------------------------
        // TAGS
        // -----------------------------
        [JsonPropertyName("conceptTags")]
        public List<string> ConceptTags { get; init; } = new();

        [JsonPropertyName("mechanicTags")]
        public List<string> MechanicTags { get; init; } = new();

        [JsonPropertyName("moodTags")]
        public List<string> MoodTags { get; init; } = new();

        [JsonPropertyName("themeTags")]
        public List<string> ThemeTags { get; init; } = new();

        [JsonPropertyName("settingTags")]
        public List<string> SettingTags { get; init; } = new();

        [JsonPropertyName("inferredDomains")]
        public List<string> InferredDomains { get; init; } = new();

        [JsonPropertyName("inferredSystems")]
        public List<string> InferredSystems { get; init; } = new();

        // -----------------------------
        // FEASIBILITY
        // -----------------------------
        [JsonPropertyName("creativePotential")]
        public string CreativePotential { get; init; } = string.Empty;

        [JsonPropertyName("productionRisks")]
        public List<string> ProductionRisks { get; init; } = new();

        [JsonPropertyName("opportunities")]
        public List<string> Opportunities { get; init; } = new();

        [JsonPropertyName("pitfalls")]
        public List<string> Pitfalls { get; init; } = new();

        [JsonPropertyName("alignmentWithGenre")]
        public string AlignmentWithGenre { get; init; } = string.Empty;

        [JsonPropertyName("expectedComplexity")]
        public string ExpectedComplexity { get; init; } = string.Empty;

        [JsonPropertyName("recommendedFocusAreas")]
        public List<string> RecommendedFocusAreas { get; init; } = new();
        
        // -----------------------------
        // METADATA
        // -----------------------------
        [JsonPropertyName("pipelineInterpretation")]
        public string PipelineInterpretation { get; init; } = string.Empty;

        [JsonPropertyName("fallbackReason")]
        public string? FallbackReason { get; init; }

        [JsonPropertyName("rawResponse")]
        public string? RawResponse { get; init; }

        [JsonPropertyName("parsedResponseJson")]
        public string? ParsedResponseJson { get; init; }
    }
}