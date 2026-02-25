namespace Nocturne.Abstractions.Genesis
{
    namespace Nocturne.Abstractions.Decks
    {
        public interface IDeck
        {
            string Name { get; }
            IReadOnlyList<ICard> Cards { get; }
            IReadOnlyDictionary<string, object> Metadata { get; }
        }
    }
}