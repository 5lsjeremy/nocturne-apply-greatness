using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainPressure
    {
        string Domain { get; }
        float Magnitude { get; }
        PressureType Type { get; }
        IReadOnlyList<string> Tags { get; }
    }
}