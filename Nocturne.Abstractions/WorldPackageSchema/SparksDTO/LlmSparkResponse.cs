namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed class LlmSparkResponse
    {
        // Definition
        public string Prompt { get; init; } = string.Empty;
        public string SparkType { get; init; } = string.Empty;
        public IReadOnlyList<string> Tags { get; init; } = Array.Empty<string>();
        public bool OverlayEligible { get; init; }

        // Metadata
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Category { get; init; } = string.Empty;
        public IReadOnlyList<string> Keywords { get; init; } = Array.Empty<string>();
        public string Lore { get; init; } = string.Empty;

        // Discovery
        public string Source { get; init; } = string.Empty;      // "lens", "prism", "designer"
        public string Trigger { get; init; } = string.Empty;
        public string Context { get; init; } = string.Empty;
        public IReadOnlyList<string> Evidence { get; init; } = Array.Empty<string>();

        // Effect Identity
        public string EffectId { get; init; } = string.Empty;
        public string EffectSlug { get; init; } = string.Empty;

        // Effect Type
        public SparkEffectType Type { get; init; }

        // Tags
        public IReadOnlyList<string> InheritedTags { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> GeneratedTags { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> DomainTags { get; init; } = Array.Empty<string>();

        // Triggers
        public IReadOnlyList<string> ActivationStates { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> SuppressionStates { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> ModificationStates { get; init; } = Array.Empty<string>();

        // Modifiers
        public IReadOnlyList<string> AllowedModifiers { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> ForbiddenModifiers { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> OverlayModifiers { get; init; } = Array.Empty<string>();

        // Accumulation
        public float StabilityContribution { get; init; }
        public float PressureContribution { get; init; }
        public float DriftContribution { get; init; }
        public string AccumulationCategory { get; init; } = string.Empty;

        // Lifespan
        public string DurationType { get; init; } = string.Empty;
        public TimeSpan? Duration { get; init; }
        public DateTime? ExpiresAt { get; init; }

        // State
        public string CurrentState { get; init; } = "active";

        // Strength
        public float BaseStrength { get; init; }
        public string CurveType { get; init; } = string.Empty;
        public IReadOnlyDictionary<string, float> CurveParameters { get; init; }
            = new Dictionary<string, float>();

        // Dependencies
        public IReadOnlyList<string> RequiredEffects { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> ConflictingEffects { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> RequiredDomainStates { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> RequiredCardStates { get; init; } = Array.Empty<string>();

        // Visibility
        public bool VisibleToDesigner { get; init; } = true;
        public bool VisibleToSimulation { get; init; } = true;
        public bool VisibleToOverlays { get; init; } = true;
        public bool VisibleInStarterPack { get; init; } = false;

        // Evidence
        public IReadOnlyList<string> SimulationLogs { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> DesignerNotes { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> ObservedBehaviors { get; init; } = Array.Empty<string>();
    }
}