using System.Text.Json;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.Surface.Nocturne.Surface.Abstractions;
using Nocturne.Abstractions.WorldPackageSchema;

namespace Nocturne.Surface.WorldPackage
{
    internal sealed class WorldPackageLoader : IWorldPackageLoader
    {
        private readonly ISurfaceLogger _logger;

        public WorldPackageLoader(ISurfaceLogger logger)
        {
            _logger = logger;
        }

        public IWorldPackageContext Load(string rootPath)
        {
            _logger.Info($"Loading world package from '{rootPath}'.");

            var worldJsonPath = Path.Combine(rootPath, "world.json");

            var package = LoadJson<Nocturne.Abstractions.WorldPackageSchema.WorldPackage>(worldJsonPath);

            var artifacts = LoadArtifacts(rootPath, package);

            var context = new WorldPackageContext(package, artifacts, _logger);

            _logger.Info("World package loaded successfully.");

            return context;
        }

        private T LoadJson<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json)!;
        }

        private LoadedArtifacts LoadArtifacts(
            string root,
            Nocturne.Abstractions.WorldPackageSchema.WorldPackage package)
        {
            var loaded = new LoadedArtifacts();

            LoadGroup(root, package.Artifacts.Concept, loaded.ConceptInternal);
            LoadGroup(root, package.Artifacts.Overlays, loaded.OverlaysInternal);
            LoadGroup(root, package.Artifacts.Domains, loaded.DomainsInternal);
            LoadGroup(root, package.Artifacts.Cards, loaded.CardsInternal);
            LoadGroup(root, package.Artifacts.StarterDeck, loaded.StarterDeckInternal);
            LoadGroup(root, package.Artifacts.Presentation, loaded.PresentationInternal);

            // surface logs
            var logsPath = Path.Combine(root, package.Artifacts.SurfaceLogs.Path);
            if (File.Exists(logsPath))
                loaded.SurfaceLogsInternal[package.Artifacts.SurfaceLogs.Path] =
                    LoadJson<object>(logsPath);

            return loaded;
        }

        private void LoadGroup(
            string root,
            object registry,
            Dictionary<string, object?> target)
        {
            var props = registry.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (prop.PropertyType == typeof(ArtifactEntry))
                {
                    var entry = (ArtifactEntry)prop.GetValue(registry)!;
                    LoadEntry(root, entry, target);
                }
                else if (typeof(Dictionary<string, ArtifactEntry>)
                    .IsAssignableFrom(prop.PropertyType))
                {
                    var dict =
                        (Dictionary<string, ArtifactEntry>)
                        prop.GetValue(registry)!;

                    foreach (var kvp in dict)
                        LoadEntry(root, kvp.Value, target);
                }
            }
        }

        private void LoadEntry(
            string root,
            ArtifactEntry entry,
            Dictionary<string, object?> target)
        {
            if (!entry.Exists)
                return;

            var path = Path.Combine(root, entry.Path);

            if (!File.Exists(path))
                return;

            target[entry.Path] = LoadJson<object>(path);
        }
    }
}