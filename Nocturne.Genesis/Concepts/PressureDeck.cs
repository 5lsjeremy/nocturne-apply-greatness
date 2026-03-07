using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class PressureDeck : IPressureDeck
    {
        private readonly List<IDomainPressure> _drawPile;
        private readonly List<IDomainPressure> _discardPile = new();

        public PressureDeck(IEnumerable<IDomainPressure> pressures)
        {
            _drawPile = pressures.ToList();
        }

        public IReadOnlyList<IDomainPressure> DrawPile => _drawPile;
        public IReadOnlyList<IDomainPressure> DiscardPile => _discardPile;

        public bool CanDraw => _drawPile.Count > 0;

        public IDomainPressure Draw()
        {
            if (!CanDraw)
                throw new InvalidOperationException("No pressures left in draw pile.");

            var pressure = _drawPile[0];
            _drawPile.RemoveAt(0);
            return pressure;
        }

        public void Discard(IDomainPressure pressure)
        {
            _discardPile.Add(pressure);
        }

        public void Reshuffle()
        {
            _drawPile.AddRange(_discardPile);
            _discardPile.Clear();
        }
    }
}