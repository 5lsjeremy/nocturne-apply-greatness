namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface ISparkSeed
    {
        string Prompt { get; }
        string SparkType { get; }
        IReadOnlyList<string> Tags { get; }
    }
}