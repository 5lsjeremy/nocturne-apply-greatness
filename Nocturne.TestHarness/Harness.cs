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

            Console.WriteLine($"World Name: {concept.Core.WorldName}");
            Console.WriteLine($"Summary: {concept.Core.Summary}");
            Console.WriteLine($"Core Fantasy: {concept.Core.CoreFantasy}");
            Console.WriteLine($"Tone: {concept.Core.Tone}");
            Console.WriteLine($"Genre: {concept.Core.Genre}");
            Console.WriteLine($"Setting: {concept.Core.Setting}");
            Console.WriteLine($"Player Fantasy: {concept.Core.PlayerFantasy}");
            Console.WriteLine($"Creative North Star: {concept.Core.CreativeNorthStar}");
            Console.WriteLine();

            Console.WriteLine("Clarity:");
            Console.WriteLine($"  Score: {concept.Clarity.ClarityScore}");
            Console.WriteLine($"  Notes: {concept.Clarity.Notes}");
            Console.WriteLine();

            Console.WriteLine("Pitch:");
            Console.WriteLine($"  Tagline: {concept.Pitch.Tagline}");
            Console.WriteLine($"  One Sentence: {concept.Pitch.OneSentencePitch}");
            Console.WriteLine($"  30-Second Pitch: {concept.Pitch.ThirtySecondPitch}");
            Console.WriteLine($"  Market Position: {concept.Pitch.MarketPosition}");
            Console.WriteLine($"  Emotional Hook: {concept.Pitch.EmotionalHook}");
            Console.WriteLine($"  Player Promise: {concept.Pitch.PlayerPromise}");
            Console.WriteLine();

            Console.WriteLine("Tags:");
            Console.WriteLine($"  Concept: {string.Join(", ", concept.Tags.ConceptTagsList)}");
            Console.WriteLine($"  Mechanics: {string.Join(", ", concept.Tags.MechanicTags)}");
            Console.WriteLine($"  Mood: {string.Join(", ", concept.Tags.MoodTags)}");
            Console.WriteLine($"  Themes: {string.Join(", ", concept.Tags.ThemeTags)}");
            Console.WriteLine($"  Setting: {string.Join(", ", concept.Tags.SettingTags)}");
            Console.WriteLine();

            Console.WriteLine("Feasibility:");
            Console.WriteLine($"  Creative Potential: {concept.Feasibility.CreativePotential}");
            Console.WriteLine($"  Alignment With Genre: {concept.Feasibility.AlignmentWithGenre}");
            Console.WriteLine($"  Expected Complexity: {concept.Feasibility.ExpectedComplexity}");
            Console.WriteLine($"  Opportunities: {string.Join(", ", concept.Feasibility.Opportunities)}");
            Console.WriteLine($"  Pitfalls: {string.Join(", ", concept.Feasibility.Pitfalls)}");
            Console.WriteLine($"  Risks: {string.Join(", ", concept.Feasibility.ProductionRisks)}");
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
            // World Package Manifest (SurfaceDTO)
            // ------------------------------------------------------------
            Console.WriteLine("=== WORLD PACKAGE ===");

            var world = session.World;

            Console.WriteLine($"WorldId: {world.WorldId}");
            Console.WriteLine($"WorldName: {world.WorldName}");
            Console.WriteLine($"Version: {world.Version}");
            Console.WriteLine($"Timestamp: {world.Timestamp}");
            Console.WriteLine();

            Console.WriteLine("Artifacts:");
            Console.WriteLine($"  Domains:        {string.Join(", ", world.DomainIds)}");
            Console.WriteLine($"  Concepts:       {string.Join(", ", world.ConceptIds)}");
            Console.WriteLine($"  Cards:          {string.Join(", ", world.CardIds)}");
            Console.WriteLine($"  Starter Decks:  {string.Join(", ", world.StarterDeckIds)}");
            Console.WriteLine($"  Presentations:  {string.Join(", ", world.PresentationIds)}");
            Console.WriteLine();

            Console.WriteLine("Presence Flags:");
            Console.WriteLine($"  HasDomains:        {world.HasDomains}");
            Console.WriteLine($"  HasConcepts:       {world.HasConcepts}");
            Console.WriteLine($"  HasCards:          {world.HasCards}");
            Console.WriteLine($"  HasStarterDecks:   {world.HasStarterDecks}");
            Console.WriteLine($"  HasPresentations:  {world.HasPresentations}");
            Console.WriteLine();

            Console.WriteLine("Paths:");
            Console.WriteLine($"  DomainsPath:       {world.DomainsPath}");
            Console.WriteLine($"  ConceptsPath:      {world.ConceptsPath}");
            Console.WriteLine($"  CardsPath:         {world.CardsPath}");
            Console.WriteLine($"  StarterDecksPath:  {world.StarterDecksPath}");
            Console.WriteLine($"  PresentationPath:  {world.PresentationPath}");
            Console.WriteLine();

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