namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainState
    {
        IReadOnlyDictionary<string, IDomainValue> Domains { get; }

        void ApplyPressure(IDomainPressure pressure);
        void ApplySpark(IDomainSpark spark);

        float WorldStability { get; }
        bool IsCollapsing { get; }
    }
}