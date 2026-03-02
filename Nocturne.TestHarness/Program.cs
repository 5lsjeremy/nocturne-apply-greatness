// See https://aka.ms/new-console-template for more information

using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;
using Nocturne.Surface.Overlays;
using Nocturne.Surface.Overlays.Engines;
using Nocturne.Surface.Overlays.Tags;
using Nocturne.Surface.Overlays.Base;

namespace Nocturne.TestHarness;

class Program
{
    static void Main()
    {
        // Instantiate default engines (DomainExtraction overridden below)
        IDomainExtractionEngine domainExtraction = new RealisticDomainExtractionEngine();
        ICardExtractionEngine cardExtraction = new CardExtractionDefault();
        IWorkOrderEngine workOrder = new WorkOrderDefault();
        IDomainEnrichmentEngine domainEnrichment = new DomainEnrichmentDefault();
        ICardEnrichmentEngine cardEnrichment = new CardEnrichmentDefault();
        IPitfallEngine pitfalls = new PitfallDefault();
        IQuestionEngine questions = new QuestionDefault();
        IReactionEngine reactions = new ReactionDefault();

        // Create inference engine
        var inference = new OverlayInferenceEngine(
            domainExtraction,
            cardExtraction,
            workOrder,
            domainEnrichment,
            cardEnrichment,
            pitfalls,
            questions,
            reactions
        );

        // Infer overlay
        var overlay = inference.InferOverlay(
            worldConcept: "A haunted bureaucratic underworld",
            pitch: "Players navigate a surreal DMV staffed by ghosts.",
            isLens: false
        );

        // Compose overlays (base + inferred)
        var composed = OverlayComposer.Compose(
            baseOverlay: overlay,
            inferredOverlay: overlay
        );

        // Create realistic test input
        var input = new RealisticDomainExtractionInput(
            composed.Tags,
            worldText: """
                The Underworld DMV is a labyrinthine office complex staffed by ghosts.
                Each department handles a different metaphysical process:
                - Soul Registration
                - Afterlife Licensing
                - Temporal Violations Appeals
                - Reincarnation Queue Management
                - Literal DMV hell ... each time you die, you have to start over again.
                - Each level makes enemies hit weaker, slows down time, generally making levelling miserable
                """
        );

        // Execute domain extraction
        var result = composed.ExtractDomains(input);

        // Print results
        Console.WriteLine("=== Realistic Domain Extraction Test ===");

        if (result is RealisticDomainExtractionOutput real)
        {
            Console.WriteLine("Extracted Domains:");
            foreach (var d in real.Domains)
                Console.WriteLine($" - {d}");
        }
        else
        {
            Console.WriteLine("Unexpected output type.");
        }
    }
}

// ----------------------------
// Realistic input type
// ----------------------------

public sealed class RealisticDomainExtractionInput : IDomainExtractionInput
{
    public IOverlayTags Tags { get; }
    public string WorldText { get; }

    public RealisticDomainExtractionInput(IOverlayTags tags, string worldText)
    {
        Tags = tags;
        WorldText = worldText;
    }
}

// ----------------------------
// Realistic output type
// ----------------------------

public sealed class RealisticDomainExtractionOutput : IDomainExtractionOutput
{
    public List<string> Domains { get; }

    public RealisticDomainExtractionOutput(List<string> domains)
    {
        Domains = domains;
    }
}

// ----------------------------
// Realistic domain extraction engine
// ----------------------------

public sealed class RealisticDomainExtractionEngine : IDomainExtractionEngine
{
    public IDomainExtractionOutput Execute(IDomainExtractionInput input)
    {
        if (input is RealisticDomainExtractionInput real)
        {
            // Fake extraction logic — simulating real behavior
            var domains = new List<string>
            {
                "Soul Registration",
                "Afterlife Licensing",
                "Temporal Violations Appeals",
                "Reincarnation Queue Management"
            };

            return new RealisticDomainExtractionOutput(domains);
        }

        // Fallback for other tests
        return new DomainExtractionOutput();
    }
}

public sealed class DomainExtractionOutput : IDomainExtractionOutput { }

// ----------------------------
// Other default engines (unchanged)
// ----------------------------

public sealed class CardExtractionDefault : ICardExtractionEngine
{
    public ICardExtractionOutput Execute(ICardExtractionInput input)
        => new CardExtractionOutput();
}

public sealed class CardExtractionOutput : ICardExtractionOutput { }

public sealed class WorkOrderDefault : IWorkOrderEngine
{
    public IWorkOrderOutput Execute(IWorkOrderInput input)
        => new WorkOrderOutput();
}

public sealed class WorkOrderOutput : IWorkOrderOutput { }

public sealed class DomainEnrichmentDefault : IDomainEnrichmentEngine
{
    public IDomainEnrichmentOutput Execute(IDomainEnrichmentInput input)
        => new DomainEnrichmentOutput();
}

public sealed class DomainEnrichmentOutput : IDomainEnrichmentOutput { }

public sealed class CardEnrichmentDefault : ICardEnrichmentEngine
{
    public ICardEnrichmentOutput Execute(ICardEnrichmentInput input)
        => new CardEnrichmentOutput();
}

public sealed class CardEnrichmentOutput : ICardEnrichmentOutput { }

public sealed class PitfallDefault : IPitfallEngine
{
    public IPitfallOutput Execute(IPitfallInput input)
        => new PitfallOutput();
}

public sealed class PitfallOutput : IPitfallOutput { }

public sealed class QuestionDefault : IQuestionEngine
{
    public IQuestionOutput Execute(IQuestionInput input)
        => new QuestionOutput();
}

public sealed class QuestionOutput : IQuestionOutput { }

public sealed class ReactionDefault : IReactionEngine
{
    public IReactionOutput Execute(IReactionInput input)
        => new ReactionOutput();
}

public sealed class ReactionOutput : IReactionOutput { }