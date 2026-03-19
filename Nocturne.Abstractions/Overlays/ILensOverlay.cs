//v.01 updated 26.03.18

namespace Nocturne.Abstractions.Overlays
{
    public interface ILensOverlay : IOverlay
    {
        // Lens-specific semantic modifiers
        IReadOnlyList<string> DriftSensitiveTags { get; }
        IReadOnlyList<string> QuestionBiasTags { get; }
        IReadOnlyList<string> UpdateHeuristicTags { get; }
    }
}