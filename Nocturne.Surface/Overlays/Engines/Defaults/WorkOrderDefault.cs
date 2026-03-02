using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;

namespace Nocturne.Surface.Overlays.Engines.Defaults
{
    public sealed class WorkOrderDefault : IWorkOrderEngine
    {
        public IWorkOrderOutput Execute(IWorkOrderInput input)
            => new WorkOrderOutput();
    }
}