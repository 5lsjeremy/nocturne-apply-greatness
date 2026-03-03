using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Lineage;

namespace Nocturne.Abstractions
{
    public interface IGenesisGenerationResult
    {
        string Narration { get; }
        IReadOnlyList<string> Tags { get; }
        ISurfaceArtifact Surface { get; }
        IDeckLineage Lineage { get; }
        IGenerationMetadata Metadata { get; }
        IGenesisSession Session { get; }
    }

}