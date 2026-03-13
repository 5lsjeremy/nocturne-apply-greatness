using Nocturne.Abstractions.WorldPackageSchema.SparksDTO;

namespace Nocturne.Abstractions.WorldPackageSchema.CardDTO
{
    public sealed record CardArtifactsDTO(
        CardDefinition Definition,
        IReadOnlyList<SparkDTO> Sparks,
        CardMetadata Metadata,
        CardLogs Logs
    );
}