using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisInferenceService
    {
        IGenesisInferenceResult Infer(IGenesisContext context, IOverlayTags? tags = null);
    }
}