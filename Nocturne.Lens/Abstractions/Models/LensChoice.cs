//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;

namespace Nocturne.Lens.Abstractions.Models
{
    public sealed class LensChoice : ILensChoice
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public string Label { get; init; } = string.Empty;
        public string? Details { get; init; }
    }
}