using Nocturne.Abstractions.Genesis;

namespace Nocturne.Abstractions;

public interface IGenesisGuards
{
    void EnsureDraft(ICard card);
    bool IsApproved(ICard card);
}