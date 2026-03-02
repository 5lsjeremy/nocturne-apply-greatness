using Nocturne.Abstractions.Overlays;

namespace Nocturne.Surface.Overlays.Tags
{
    public sealed class OverlayTags : IOverlayTags
    {
        public string Tone { get; init; }
        public string Density { get; init; }
        public string Style { get; init; }
        public string WorldType { get; init; }
        public string Risk { get; init; }

        public OverlayTags(
            string tone = "neutral",
            string density = "medium",
            string style = "literal",
            string worldType = "generic",
            string risk = "medium")
        {
            Tone = tone;
            Density = density;
            Style = style;
            WorldType = worldType;
            Risk = risk;
        }
    }
}