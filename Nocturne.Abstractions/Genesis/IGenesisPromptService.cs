using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisPromptService
    {
        Task RunMvpLoopAsync(IGenesisContext context, IOverlayTags? tags = null);
    }
}