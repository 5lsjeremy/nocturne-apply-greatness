using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;

namespace Nocturne.Surface.Overlays.Engines.Defaults
{
    public sealed class ReactionDefault : IReactionEngine
    {
        public IReactionOutput Execute(IReactionInput input)
            => new ReactionOutput();
    }
}