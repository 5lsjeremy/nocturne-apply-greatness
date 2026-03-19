
//v.01 updated 26.03.18
namespace Nocturne.Abstractions.Lens
{
    public interface ILensDiff
    {
        IReadOnlyList<string> Added { get; }
        IReadOnlyList<string> Removed { get; }
        IReadOnlyList<string> Modified { get; }
    }
}