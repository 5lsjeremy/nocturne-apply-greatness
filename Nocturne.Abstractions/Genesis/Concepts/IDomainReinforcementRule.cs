namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainReinforcementRule
    {
        bool AppliesTo(IDomainSpark spark);
        float ModifyIncomingReinforcement(float reinforcement);
    }
}