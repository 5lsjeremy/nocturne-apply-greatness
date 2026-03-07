using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Surface;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class ConceptMetadata : IConceptMetadata
    {
        private readonly List<ISurfaceLogEntry> _logs = new();

        public IReadOnlyCollection<ISurfaceLogEntry> Logs => _logs;

        public string? RawResponse { get; set; }
        public string? ParsedResponseJson { get; set; }
        public string? PipelineInterpretation { get; set; }
        public string? FallbackReason { get; set; }

        // Internal helper for Genesis to append logs
        internal void AddLog(ISurfaceLogEntry entry) => _logs.Add(entry);
    }

}