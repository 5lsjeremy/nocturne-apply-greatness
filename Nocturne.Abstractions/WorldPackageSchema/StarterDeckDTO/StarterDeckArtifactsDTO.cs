namespace Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO
{
    public sealed record StarterDeckArtifactsDTO(
        StarterDeckDefinition Definition,
        StarterDeckMetadata Metadata,
        StarterDeckLogs Logs
    );
}