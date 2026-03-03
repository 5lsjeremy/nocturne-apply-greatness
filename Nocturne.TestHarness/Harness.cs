using System;
using System.Threading.Tasks;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Overlays;

namespace Nocturne.TestHarness
{
    // ------------------------------------------------------------
    // Concrete seed artifact (allowed)
    // ------------------------------------------------------------
    public sealed class TestSurfaceArtifact : ISurfaceArtifact
    {
        public string Id { get; }
        public string Name { get; }

        public TestSurfaceArtifact(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
        }
    }

    // ------------------------------------------------------------
    // Concrete IGenesisOptions (allowed)
    // ------------------------------------------------------------
    public sealed class TestGenesisOptions : IGenesisOptions
    {
        public bool? OfflineMode { get; init; }
        public string? PromptSetPath { get; init; }
        public string? LocalizationPath { get; init; }
        public bool? DarkMode { get; init; }
    }

    // ------------------------------------------------------------
    // Pure interface-based harness
    // ------------------------------------------------------------
    public static class Harness
    {
        public static async Task Run(IGenesisFactory factory, IOverlayTags? tags = null)
        {
            Console.WriteLine("Booting Genesis through interface-only harness...");

            var seed = new TestSurfaceArtifact("Haunted DMV");

            var options = new TestGenesisOptions
            {
                OfflineMode = false
            };

            var engine = factory.Create(seed, options);

            Console.WriteLine("Calling IGenesisEngine.GenerateAsync...");
            var session = await engine.GenerateAsync(tags);

            Console.WriteLine("Genesis session created: " + (session != null ? "OK" : "NULL"));
            Console.WriteLine();
            Console.WriteLine("=== GENESIS OUTPUT ===");

            // Narration
            Console.WriteLine();
            Console.WriteLine("Narration:");
            Console.WriteLine(session?.Narration ?? "(none)");

            // Tags
            Console.WriteLine();
            Console.WriteLine("Tags:");
            if (session?.Tags != null)
            {
                foreach (var tag in session.Tags)
                    Console.WriteLine($" - {tag}");
            }
            else
            {
                Console.WriteLine("(none)");
            }

            // Surface
            Console.WriteLine();
            Console.WriteLine("Surface Artifact:");
            Console.WriteLine(session?.Surface?.ToString() ?? "(none)");

            // Lineage
            Console.WriteLine();
            Console.WriteLine("Lineage:");
            Console.WriteLine(session?.Lineage?.ToString() ?? "(none)");

            // Metadata
            Console.WriteLine();
            Console.WriteLine("Metadata:");
            Console.WriteLine($"  Model: {session?.Metadata?.Model}");
            Console.WriteLine($"  Duration: {session?.Metadata?.DurationMs} ms");
            Console.WriteLine($"  Seed: {session?.Metadata?.Seed}");

            Console.WriteLine();
            Console.WriteLine("=== END OF GENESIS OUTPUT ===");
        }
    }
}