namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainSeed
    {
        // Core identity
        string Name { get; }
        string? Summary { get; }

        // Semantic descriptors (LLM-driven)
        IReadOnlyList<string> Vectors { get; }
        IReadOnlyList<string> Stats { get; }
        IReadOnlyList<string> Behaviors { get; }

        // Natural-language rule descriptions (LLM-driven)
        IReadOnlyList<string> ProtectionRules { get; }
        IReadOnlyList<string> ReinforcementRules { get; }

        // Optional numeric hints (LLM or designer)
        float? DefaultThreshold { get; }
        float? DefaultGravity { get; }
    }
}