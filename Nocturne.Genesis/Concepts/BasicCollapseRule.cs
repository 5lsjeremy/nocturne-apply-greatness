using Nocturne.Abstractions.Genesis.Concepts;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class BasicCollapseRule
    {
        public static bool Check(IDomainValue value, IWorldContext world)
            => value.Current <= 0 || world.Flags.HasFlag(WorldFlags.CollapseImminent);
    }
}