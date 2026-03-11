using System.Text.Json;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema;
using Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO;
using Nocturne.Surface.Diagnostics;
using Nocturne.Surface.WorldPackage;

namespace Nocturne.Surface.Builders
{
    internal sealed class WorldPackageBuilder : IWorldPackageBuilder
    {
        private readonly SurfaceLogger _logger;

        public WorldPackageBuilder(SurfaceLogger logger)
        {
            _logger = logger;
        }

        private void WriteConceptArtifacts(
            IGenesisSession session,
            string root,
           Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO.WorldPackage world)
        {
            var conceptRoot = Path.Combine(root, world.Artifacts.Concept.Root);
            Directory.CreateDirectory(conceptRoot);
            _logger.Info("Created concept/ folder.");

            WriteJson(Path.Combine(conceptRoot, "concept.json"),
                session.Concept.Core,
                world.Artifacts.Concept.Concept);

            WriteJson(Path.Combine(conceptRoot, "clarity.json"),
                session.Concept.Evaluation,
                world.Artifacts.Concept.Clarity);

            WriteJson(Path.Combine(conceptRoot, "pitch.json"),
                session.Concept.Core.Pitch,
                world.Artifacts.Concept.Pitch);

            WriteJson(Path.Combine(conceptRoot, "tags.json"),
                session.Concept.Extraction.Tags,
                world.Artifacts.Concept.Tags);

            WriteJson(Path.Combine(conceptRoot, "feasibility.json"),
                session.Concept.Evaluation,
                world.Artifacts.Concept.Feasibility);

            WriteJson(Path.Combine(conceptRoot, "logs.json"),
                session.ConceptLogs,
                world.Artifacts.Concept.Logs);
        }

        private void WriteEmptyScaffolds(string root, Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO.WorldPackage world)
        {
            Directory.CreateDirectory(Path.Combine(root, world.Artifacts.Overlays.Root));
            Directory.CreateDirectory(Path.Combine(root, world.Artifacts.Domains.Root));
            Directory.CreateDirectory(Path.Combine(root, world.Artifacts.Cards.Root));
            Directory.CreateDirectory(Path.Combine(root, world.Artifacts.StarterDeck.Root));
            Directory.CreateDirectory(Path.Combine(root, world.Artifacts.Presentation.Root));

            _logger.Info("Created all scaffold folders.");
        }

        private void WriteSurfaceLogs(string root, Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO.WorldPackage world)
        {
            var surfaceRoot = Path.Combine(root, "surface");
            Directory.CreateDirectory(surfaceRoot);

            WriteJson(
                Path.Combine(surfaceRoot, "logs.json"),
                _logger.Entries,
                world.Artifacts.SurfaceLogs
            );

            _logger.Info("Wrote surface/logs.json.");
        }

        private static void WriteJson<T>(string path, T obj, ArtifactEntry entry)
        {
            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);

            entry.Exists = true;
            entry.Timestamp = DateTime.UtcNow;
            entry.Version += 1;
            entry.Hash = ComputeHash(json);
        }

        private static string ComputeHash(string content)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(content);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }

        public void WriteInitialPackage(IGenesisSession session, ISurfaceWorldContext context)
        {
            _logger.Info("Starting world package build.");

            Directory.CreateDirectory(context.RootPath);
            _logger.Info($"Created world root at '{context.RootPath}'.");

            var world = new Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO.WorldPackage
            {
                WorldName = context.WorldName,
                Version = context.Version,
                SeedId = session.SeedId,
                Timestamp = session.Timestamp,
                Lifecycle = "cache"
            };

            WriteConceptArtifacts(session, context.RootPath, world);
            WriteEmptyScaffolds(context.RootPath, world);
            WriteSurfaceLogs(context.RootPath, world);

            WriteJson(
                Path.Combine(context.RootPath, "world.json"),
                world,
                world.Artifacts.SurfaceLogs // world.json is also logged
            );

            _logger.Info("world.json written successfully.");
            _logger.Info("World package build completed.");
        }
    }
}