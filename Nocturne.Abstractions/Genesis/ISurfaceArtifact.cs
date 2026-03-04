namespace Nocturne.Abstractions.Genesis
{
    public interface ISurfaceArtifact : IArtifact
    {
        // Minimal contract for Genesis:
        string Name { get; }
        // You can extend this later with seed-specific data if needed.
        string WorldConcept { get; }
    }
}