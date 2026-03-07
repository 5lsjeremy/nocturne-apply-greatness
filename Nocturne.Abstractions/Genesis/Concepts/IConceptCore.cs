namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IConceptCore
    {
        string WorldConcept { get; }
        string? Fantasy { get; }
        string? CoreLoop { get; }
        IReadOnlyList<string> Verbs { get; }
        IReadOnlyList<string> Constraints { get; }
        string? Tone { get; }
        string? Pitch { get; }
    }
}