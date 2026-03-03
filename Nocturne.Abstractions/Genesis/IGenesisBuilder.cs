using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis;

public interface IGenesisBuilder
{
    IStarterDeck BuildStarterDeck(
        ISurfaceArtifact seed,
        IGenesisContext context,
        IGenesisInferenceResult inference,
        string inferenceRunId,
        IOverlayTags? tags = null
    );
}