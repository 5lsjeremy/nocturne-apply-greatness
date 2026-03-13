using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;

public sealed record DomainArtifactsDTO(
    DomainDefinition Definition,
    IReadOnlyList<CardArtifactsDTO> Cards,
    DomainClarity Clarity,
    DomainFeasibility Feasibility,
    DomainLogs Logs
);