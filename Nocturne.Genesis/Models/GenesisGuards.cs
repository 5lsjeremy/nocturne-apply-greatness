using Nocturne.Abstractions;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Enums;

namespace Nocturne.Genesis.Models;

internal sealed class GenesisGuards : IGenesisGuards
{
    public void EnsureDraft(ICard card)
    {
        if (card.State == CardStatusDetails.ArtifactState.Approved)
            throw new InvalidOperationException("Approved artifacts cannot be modified.");
    }

    public bool IsApproved(ICard card)
    {
        return card.State == CardStatusDetails.ArtifactState.Approved;
    }
}