using Nocturne.Abstractions;

namespace Nocturne.Surface.Abstractions
{
    public interface ISurface :
        IIdentifiable,
        IHasMetadata<SurfaceMetadata>,
        IHasTags
    {
        IReadOnlyCollection<ISpace> Spaces { get; }
    }
}