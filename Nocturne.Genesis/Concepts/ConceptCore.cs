using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class ConceptCore : IConceptCore
    {
        public string WorldConcept { get; set; } = "";
        public string? Fantasy { get; set; }
        public string? CoreLoop { get; set; }
        public IReadOnlyList<string> Verbs { get; set; } = Array.Empty<string>();
        public IReadOnlyList<string> Constraints { get; set; } = Array.Empty<string>();
        public string? Tone { get; set; }
        public string? Pitch { get; set; }
    }
}