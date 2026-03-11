using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Surface;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.SurfaceDTO;

public interface IGenesisSession
{
    string SeedId { get; }
    DateTime Timestamp { get; }

    // NEW — the full world package
    SurfaceDTO World { get; }

    // Optional — the concept DTO if you want to expose it
    public IConcept Concept { get; init; }
    
    // RESTORE THESE FOR HARNESS COMPATIBILITY
    IReadOnlyList<ICard> Cards { get; }
    IStarterDeck StarterDeck { get; }


    IReadOnlyCollection<ISurfaceLogEntry> ConceptLogs { get; }
    string InferenceRunId { get; }
    IReadOnlyDictionary<string, string> PromptAnswers { get; }
}