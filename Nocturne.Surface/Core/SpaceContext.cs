using Nocturne.Surface.Abstractions;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Surface.Core;

internal sealed class SpaceContext
{
    internal ISpace Space { get; }
    internal SurfaceLogger Logger { get; }

    internal SpaceContext(ISpace space)
    {
        Space = space;
        Logger = new SurfaceLogger();

        Logger.Info($"Initialized SpaceContext for space '{space.Id}'");
    }
}