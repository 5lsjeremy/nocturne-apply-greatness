using Nocturne.Abstractions.Surface;

namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed record ConceptMetadata
    (
        string? RawResponse,
        string? ParsedResponseJson,
        string? PipelineInterpretation,
        string? FallbackReason,
        IReadOnlyCollection<ISurfaceLogEntry> Logs
    );
}