//v.01 updated 26.03.18
using Nocturne.Abstractions.Overlays;

namespace Nocturne.Surface.Overlays
{
    public sealed class OverlayComposer : IOverlayComposer
    {
        public IOverlay Compose(
            IOverlay baseOverlay,
            IOverlay inferredOverlay,
            IOverlay? customOverlay = null)
        {
            return new CompositeOverlay(baseOverlay, inferredOverlay, customOverlay);
        }
    }
}