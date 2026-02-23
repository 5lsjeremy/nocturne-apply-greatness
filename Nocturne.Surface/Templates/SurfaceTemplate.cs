using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Builders;

namespace Nocturne.Surface.Templates
{
    public abstract class SurfaceTemplate : DefaultSurface
    {
        protected SurfaceTemplate(
            string id,
            Action<SurfaceMetadataBuilder> configure)
            : base(id, configure)
        {
        }

        protected void AddSpace(
            string id,
            Action<ISpaceMetadataBuilder> configure,
            IReadOnlyCollection<IRegion> regions)
        {
            var space = new DefaultSpace(id, configure, regions);
            AddSpaceInternal(space);
        }

        private void AddSpaceInternal(ISpace space)
        {
            base.AddSpace(space);
        }
    }
}