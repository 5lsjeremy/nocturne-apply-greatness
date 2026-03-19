//v.01 updated 26.03.18

using Nocturne.Abstractions.Lens;

namespace Nocturne.Lens.Abstractions.Models
{
    internal sealed class LensDiff : ILensDiff
    {
        public IReadOnlyList<string> Added { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> Removed { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> Modified { get; init; } = Array.Empty<string>();
    }
}