namespace Nocturne.Abstractions.WorldPackageSchema.PresentationDTO
{
    public sealed record PresentationArtifactsDTO(
        PresentationDefinition Definition,
        PresentationMetadata Metadata,
        PresentationLogs Logs
    );
}