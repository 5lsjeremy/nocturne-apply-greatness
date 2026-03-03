using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisEngine
    {
        // NEW overlay-aware signature
        Task<IGenesisSession> GenerateAsync(IOverlayTags? tags = null);
        ICard Riff(ICard card, string contributor, string prompt);
    }
}