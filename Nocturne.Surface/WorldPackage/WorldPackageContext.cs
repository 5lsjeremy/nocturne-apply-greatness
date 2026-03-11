using Nocturne.Abstractions.Surface;

namespace Nocturne.Surface.WorldPackage
{
    internal class WorldPackageContext : IWorldPackageContext
    {
        public Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO.WorldPackage Package { get; }
        public ILoadedArtifacts Artifacts { get; }
        public ISurfaceLogger Logger { get; }

        public WorldPackageContext(
            Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO.WorldPackage package,
            ILoadedArtifacts artifacts,
            ISurfaceLogger logger)
        {
            Package = package;
            Artifacts = artifacts;
            Logger = logger;
        }
    }
}