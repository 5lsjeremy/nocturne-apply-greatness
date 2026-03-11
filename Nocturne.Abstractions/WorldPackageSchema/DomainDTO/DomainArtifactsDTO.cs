namespace Nocturne.Abstractions.WorldPackageSchema.DomainDTO
{
    public sealed record DomainArtifactsDTO(
        DomainDefinition Definition,
        DomainClarity Clarity,
        DomainFeasibility Feasibility,
        DomainLogs Logs
    );
}