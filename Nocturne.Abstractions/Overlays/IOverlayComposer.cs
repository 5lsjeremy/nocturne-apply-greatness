//v.01 updated 26.03.18

namespace Nocturne.Abstractions.Overlays
{
    public interface IOverlayComposer
    {
        IOverlay Compose(IOverlay baseOverlay, IOverlay inferredOverlay, IOverlay? customOverlay = null);
    }
}