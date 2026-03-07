using System;
using System.Linq;
using System.Threading.Tasks;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Overlays;

namespace Nocturne.TestHarness
{
    public sealed class TestSurfaceArtifact : ISurfaceArtifact
    {
        public string Id { get; }
        public string Name { get; }
        public string WorldConcept { get; }

        public TestSurfaceArtifact(string name, string worldConcept)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            WorldConcept = worldConcept;
        }
    }

    public sealed class TestGenesisOptions : IGenesisOptions
    {
        public bool? OfflineMode { get; init; }
        public string? PromptSetPath { get; init; }
        public string? LocalizationPath { get; init; }
        public bool? DarkMode { get; init; }
    }

    public static class Harness
    {
        public static async Task Run(
            IGenesisFactory factory,
            ISurfaceArtifact artifact,
            IOverlayTags? tags = null)
        {
            Console.WriteLine("Booting Genesis through interface-only harness...");

            var options = new TestGenesisOptions
            {
                OfflineMode = false
            };

            var engine = factory.Create(artifact, options);

            Console.WriteLine("Calling IGenesisEngine.GenerateAsync...");
            var session = await engine.GenerateAsync(tags);

            Console.WriteLine();
            Console.WriteLine("=== GENESIS SESSION ===");
            Console.WriteLine($"SeedId: {session.SeedId}");
            Console.WriteLine($"Timestamp: {session.Timestamp}");
            Console.WriteLine();

            // ------------------------------------------------------------
            // Concept
            // ------------------------------------------------------------
            Console.WriteLine("=== CONCEPT ===");

            var concept = session.Concept;
            var core = concept.Core;
            var eval = concept.Evaluation;
            var extract = concept.Extraction;

            Console.WriteLine($"World Concept: {core.WorldConcept}");
            Console.WriteLine($"Clarity: {(eval.IsClear == true ? "clear" : "unclear")}");
            Console.WriteLine($"Pitch: {core.Pitch ?? "(none)"}");

            if (extract.Tags != null)
            {
                Console.WriteLine(
                    $"Tags: tone={extract.Tags.Tone}, density={extract.Tags.Density}, risk={extract.Tags.Risk}"
                );
            }
            else
            {
                Console.WriteLine("Tags: (none)");
            }

            if (eval.ClarityRecommendations.Any())
                Console.WriteLine($"Clarity Rec: {eval.ClarityRecommendations.First()}");

            Console.WriteLine();

            // ------------------------------------------------------------
            // Concept Logs
            // ------------------------------------------------------------
            Console.WriteLine("=== CONCEPT LOGS ===");

            if (session.ConceptLogs == null || session.ConceptLogs.Count == 0)
            {
                Console.WriteLine("(no logs)");
            }
            else
            {
                foreach (var group in session.ConceptLogs.GroupBy(l => l.Category))
                {
                    Console.WriteLine($"[{group.Key}]");

                    foreach (var log in group.OrderBy(l => l.Timestamp))
                    {
                        Console.WriteLine($"  {log.Timestamp:HH:mm:ss}  {log.Message}");
                    }

                    Console.WriteLine();
                }
            }

            // ------------------------------------------------------------
            // Worlds
            // ------------------------------------------------------------
            var world = concept.World;

            Console.WriteLine("=== WORLD DOMAINS ===");
            foreach (var kv in world.DomainState.Domains)
            {
                var name = kv.Key;
                var value = kv.Value;
                Console.WriteLine($"{name}: {value.Current}/{value.Threshold}");
            }

            Console.WriteLine($"World Stability: {world.DomainState.WorldStability}");
            Console.WriteLine($"Is Collapsing: {world.DomainState.IsCollapsing}");

            // ------------------------------------------------------------
            // Cards
            // ------------------------------------------------------------
            Console.WriteLine("=== CARDS ===");
            foreach (var card in session.Cards)
                Console.WriteLine($" - {card.Id}: {card.Name}");

            Console.WriteLine();

            // ------------------------------------------------------------
            // Starter Deck
            // ------------------------------------------------------------
            Console.WriteLine("=== STARTER DECK ===");
            Console.WriteLine($"Deck Name: {session.StarterDeck.Name}");
            Console.WriteLine("Cards:");
            foreach (var card in session.StarterDeck.Cards)
                Console.WriteLine($"   - {card.Id}: {card.Name}");

            Console.WriteLine();
            Console.WriteLine("=== END OF GENESIS OUTPUT ===");
        }
    }
}