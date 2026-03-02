using Nocturne.Abstractions.Overlays;

namespace Nocturne.Surface.Overlays
{
    public static class OverlayComposer
    {
        public static IOverlay Compose(
            IOverlay baseOverlay,
            IOverlay inferredOverlay,
            IOverlay? customOverlay = null)
        {
            return new CompositeOverlay(baseOverlay, inferredOverlay, customOverlay);
        }
    }
}