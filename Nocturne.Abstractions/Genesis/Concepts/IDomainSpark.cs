using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainSpark
    {
        string Domain { get; }
        float Magnitude { get; }
        SparkType Type { get; }
        IReadOnlyList<string> Tags { get; }
    }
}