using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class SparkDeck : ISparkDeck
    {
        private readonly List<IDomainSpark> _drawPile;
        private readonly List<IDomainSpark> _discardPile = new();

        public SparkDeck(IEnumerable<IDomainSpark> sparks)
        {
            _drawPile = sparks.ToList();
        }

        public IReadOnlyList<IDomainSpark> DrawPile => _drawPile;
        public IReadOnlyList<IDomainSpark> DiscardPile => _discardPile;

        public bool CanDraw => _drawPile.Count > 0;

        public IDomainSpark Draw()
        {
            if (!CanDraw)
                throw new InvalidOperationException("No sparks left in draw pile.");

            var spark = _drawPile[0];
            _drawPile.RemoveAt(0);
            return spark;
        }

        public void Discard(IDomainSpark spark)
        {
            _discardPile.Add(spark);
        }

        public void Reshuffle()
        {
            _drawPile.AddRange(_discardPile);
            _discardPile.Clear();
        }
    }
}