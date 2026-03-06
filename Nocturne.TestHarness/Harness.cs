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

        public TestSurfaceArtifact(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
            WorldConcept = "Man is kidnapped by dolphins and forced to build underwater city.  He must adapt and use their tools, their tech, and their techniques.  Nothing human is accepted here.";
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