using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class DomainSpark : IDomainSpark
    {
        public string Domain { get; init; } = "";
        public float Magnitude { get; init; }
        public SparkType Type { get; init; }
        public IReadOnlyList<string> Tags { get; init; } = Array.Empty<string>();
    }
}