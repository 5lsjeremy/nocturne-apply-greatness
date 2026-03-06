namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface ICollapseRule
    {
        bool CheckCollapse(IDomainState state);
    }
}