using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class DomainPressure : IDomainPressure
    {
        public string Domain { get; init; } = "";
        public float Magnitude { get; init; }
        public PressureType Type { get; init; }
        public IReadOnlyList<string> Tags { get; init; } = Array.Empty<string>();
    }
}