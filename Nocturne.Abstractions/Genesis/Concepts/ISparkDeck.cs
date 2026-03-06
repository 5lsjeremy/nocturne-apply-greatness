namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface ISparkDeck
    {
        IReadOnlyList<IDomainSpark> DrawPile { get; }
        IReadOnlyList<IDomainSpark> DiscardPile { get; }

        bool CanDraw { get; }
        IDomainSpark Draw();
        void Discard(IDomainSpark spark);
        void Reshuffle();
    }
}