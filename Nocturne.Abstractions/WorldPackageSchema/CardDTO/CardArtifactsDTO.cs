namespace Nocturne.Abstractions.WorldPackageSchema.CardDTO
{
    public sealed record CardArtifactsDTO(
        CardDefinition Definition,
        CardMetadata Metadata,
        CardLogs Logs
    );
}