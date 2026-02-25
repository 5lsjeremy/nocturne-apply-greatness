using Nocturne.Abstractions;
using Nocturne.Abstractions.Surface;
using Nocturne.Surface.Metadata;

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