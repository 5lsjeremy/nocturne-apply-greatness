namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IPressureDeck
    {
        IReadOnlyList<IDomainPressure> DrawPile { get; }
        IReadOnlyList<IDomainPressure> DiscardPile { get; }

        bool CanDraw { get; }
        IDomainPressure Draw();
        void Discard(IDomainPressure pressure);
        void Reshuffle();
    }
}