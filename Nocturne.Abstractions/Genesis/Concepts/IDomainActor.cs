namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainActor
    {
        void ApplyPressure(IDomainPressure pressure);
        void ApplySpark(IDomainSpark spark);
    }
}