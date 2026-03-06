namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IPressureSeed
    {
        string Domain { get; }
        string PressureType { get; }
        string Prompt { get; }
        IReadOnlyList<string> Tags { get; }
    }
}