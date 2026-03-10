using System.Collections.Generic;
using Nocturne.Abstractions.Surface;
using Nocturne.Surface.Abstractions;

namespace Nocturne.Surface.WorldPackage
{
    internal sealed class LoadedArtifacts : ILoadedArtifacts
    {
        public Dictionary<string, object?> ConceptInternal { get; } = new();
        public Dictionary<string, object?> OverlaysInternal { get; } = new();
        public Dictionary<string, object?> DomainsInternal { get; } = new();
        public Dictionary<string, object?> CardsInternal { get; } = new();
        public Dictionary<string, object?> StarterDeckInternal { get; } = new();
        public Dictionary<string, object?> PresentationInternal { get; } = new();
        public Dictionary<string, object?> SurfaceLogsInternal { get; } = new();

        public IReadOnlyDictionary<string, object?> Concept => ConceptInternal;
        public IReadOnlyDictionary<string, object?> Overlays => OverlaysInternal;
        public IReadOnlyDictionary<string, object?> Domains => DomainsInternal;
        public IReadOnlyDictionary<string, object?> Cards => CardsInternal;
        public IReadOnlyDictionary<string, object?> StarterDeck => StarterDeckInternal;
        public IReadOnlyDictionary<string, object?> Presentation => PresentationInternal;
        public IReadOnlyDictionary<string, object?> SurfaceLogs => SurfaceLogsInternal;
    }
}