namespace Nocturne.Abstractions.Genesis;

public interface IGenesisGuards
{
    void EnsureDraft(ICard card);
    bool IsApproved(ICard card);
}