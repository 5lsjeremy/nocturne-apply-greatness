using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class PressureSeed : IPressureSeed
    {
        public string Domain { get; set; } = "";
        public string PressureType { get; set; } = "";
        public string Prompt { get; set; } = "";
        public IReadOnlyList<string> Tags { get; set; } = Array.Empty<string>();
    }
}