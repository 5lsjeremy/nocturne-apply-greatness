namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisBuilder
    {
        IStarterDeck BuildStarterDeck(IGenesisContext context);
    }
}