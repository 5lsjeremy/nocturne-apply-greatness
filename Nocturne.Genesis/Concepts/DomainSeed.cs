using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class DomainSeed : IDomainSeed
    {
        public string Name { get; set; } = "";
        public string? Summary { get; set; }

        // Semantic descriptors (LLM-driven)
        public IReadOnlyList<string> Vectors { get; set; } = Array.Empty<string>();
        public IReadOnlyList<string> Stats { get; set; } = Array.Empty<string>();
        public IReadOnlyList<string> Behaviors { get; set; } = Array.Empty<string>();

        // Rule descriptions (LLM-driven natural language)
        public IReadOnlyList<string> ProtectionRules { get; set; } = Array.Empty<string>();
        public IReadOnlyList<string> ReinforcementRules { get; set; } = Array.Empty<string>();

        // Optional numeric hints (LLM or designer)
        public float? DefaultThreshold { get; set; }
        public float? DefaultGravity { get; set; }
    }
}