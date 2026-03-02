using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;

namespace Nocturne.Surface.Overlays.Engines.Defaults
{
    public sealed class PitfallDefault : IPitfallEngine
    {
        public IPitfallOutput Execute(IPitfallInput input)
            => new PitfallOutput();
    }
}