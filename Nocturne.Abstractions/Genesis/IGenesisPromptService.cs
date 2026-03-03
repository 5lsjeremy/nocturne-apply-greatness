using Nocturne.Abstractions.Overlays;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisPromptService
    {
        void RunMvpLoop(IGenesisContext context, IOverlayTags? tags = null);
    }

}