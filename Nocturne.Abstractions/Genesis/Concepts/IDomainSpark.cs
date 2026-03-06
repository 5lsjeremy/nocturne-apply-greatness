using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainSpark
    {
        string Domain { get; }
        float Reinforcement { get; }
        SparkType Type { get; }
    }
}