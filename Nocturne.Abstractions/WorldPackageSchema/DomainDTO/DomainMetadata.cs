using System;
using System.Collections.Generic;

namespace Nocturne.Abstractions.WorldPackageSchema.DomainDTO
{
    public sealed record DomainMetadata
    {
        public string DomainId { get; init; } = string.Empty;

        // Deterministic SHA256 fingerprint of the LLM domain response
        public string Fingerprint { get; init; } = string.Empty;

        // Version of the artifact (incremented by your pipeline)
        public int Version { get; init; }

        // “genesis”, “import”, “manual”, etc.
        public string Origin { get; init; } = string.Empty;

        // When this metadata was generated
        public DateTime Timestamp { get; init; }

        // Optional: lineage chain (future‑proofing)
        public List<string> ParentFingerprints { get; init; } = new();

        // Optional: tags for overlays, governance, or PRISM
        public List<string> Tags { get; init; } = new();
    }
}