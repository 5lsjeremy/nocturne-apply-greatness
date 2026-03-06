using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    public record DomainValue : IDomainValue
    {
        public float Current { get; set; }
        public float Gravity { get; set; }
        public float Threshold { get; set; }

        // No Clone() method needed — use `with` instead.
    }
}