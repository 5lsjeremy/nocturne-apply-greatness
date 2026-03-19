//v.01 updated 26.03.18

using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Lens.Enums;

namespace Nocturne.Lens.Abstractions.Models
{
    public sealed class LensQuestion : ILensQuestion
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public string Prompt { get; init; } = string.Empty;

        public IReadOnlyList<ILensChoice> Choices { get; init; }
            = Array.Empty<ILensChoice>();
        
        public string Domain { get; init; } = string.Empty;

        public IReadOnlyList<string> RelatedArtifactIds { get; init; }
            = Array.Empty<string>();

        public LensPassType SourcePass { get; init; }
    }
}