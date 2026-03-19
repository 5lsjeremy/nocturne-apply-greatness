using Nocturne.Abstractions.Lens.Enums;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensQuestion
    {
        string Id { get; }
        string Prompt { get; }
        IReadOnlyList<ILensChoice> Choices { get; }

        string Domain { get; }                       // NEW
        IReadOnlyList<string> RelatedArtifactIds { get; } // NEW
        LensPassType SourcePass { get; }             // NEW
    }
}