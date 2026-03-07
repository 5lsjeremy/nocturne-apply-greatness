using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IConceptMetadata
    {
        string? RawResponse { get; }
        string? ParsedResponseJson { get; }
        string? PipelineInterpretation { get; }
        string? FallbackReason { get; }

        IReadOnlyCollection<ISurfaceLogEntry> Logs { get; }
    }
}