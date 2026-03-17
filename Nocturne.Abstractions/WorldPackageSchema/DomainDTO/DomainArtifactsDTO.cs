using Nocturne.Abstractions.WorldPackageSchema.CardDTO;

namespace Nocturne.Abstractions.WorldPackageSchema.DomainDTO;

public sealed record DomainArtifactsDTO(
    DomainDefinition Definition,
    IReadOnlyList<CardArtifactsDTO> Cards,
    DomainClarity Clarity,
    DomainFeasibility Feasibility,
    DomainMetadata Metadata,
    DomainLogs Logs
);