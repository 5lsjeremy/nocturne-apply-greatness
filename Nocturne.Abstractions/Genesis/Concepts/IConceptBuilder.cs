using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IConceptBuilder
    {
        string WorldConcept { get; }

        void SetClarity(bool isClear, IReadOnlyList<string> recommendations, IReadOnlyList<string> questions);
        void SetPitch(string? pitch, IReadOnlyList<string> recommendations);
        void SetTags(IOverlayTags? tags, IReadOnlyList<string> recommendations);

        void MarkFailure(string reason);
        void MarkSuccess();

        IConcept Build();
    }
}