namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO;

public sealed record SparkArtifact(
    SparkDefinition Definition,
    SparkMetadata Metadata,
    SparkDiscovery Discovery,
    SparkEffects Effects,
    SparkLogs Logs
);