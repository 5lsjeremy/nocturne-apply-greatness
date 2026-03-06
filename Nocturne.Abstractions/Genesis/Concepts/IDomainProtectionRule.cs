namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainProtectionRule
    {
        bool AppliesTo(IDomainPressure pressure);
        float ModifyIncomingPressure(float magnitude);
    }
}