using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class SparkSeed : ISparkSeed
    {
        public string Prompt { get; set; } = "";
        public string SparkType { get; set; } = "mechanical";
        public IReadOnlyList<string> Tags { get; set; } = Array.Empty<string>();
    }
}