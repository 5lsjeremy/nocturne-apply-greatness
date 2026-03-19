//v.01 updated 26.03.18

namespace Nocturne.Abstractions.Overlays
{
    public interface ICompositeOverlay : IOverlay
    {
        IOverlay Base { get; }
        IOverlay Inferred { get; }
        IOverlay? Custom { get; }
    }
}