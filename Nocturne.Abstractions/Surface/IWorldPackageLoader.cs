using Nocturne.Abstractions.WorldPackageSchema;

namespace Nocturne.Abstractions.Surface
{
    namespace Nocturne.Surface.Abstractions
    {
        public interface IWorldPackageLoader
        {
            IWorldPackageContext Load(string rootPath);
        }
    }
    public interface IWorldPackageContext
    {
        WorldPackage Package { get; }
        ILoadedArtifacts Artifacts { get; }
        ISurfaceLogger Logger { get; }
    }

    
    public interface ILoadedArtifacts
    {
        IReadOnlyDictionary<string, object?> Concept { get; }
        IReadOnlyDictionary<string, object?> Overlays { get; }
        IReadOnlyDictionary<string, object?> Domains { get; }
        IReadOnlyDictionary<string, object?> Cards { get; }
        IReadOnlyDictionary<string, object?> StarterDeck { get; }
        IReadOnlyDictionary<string, object?> Presentation { get; }
        IReadOnlyDictionary<string, object?> SurfaceLogs { get; }
    }

}