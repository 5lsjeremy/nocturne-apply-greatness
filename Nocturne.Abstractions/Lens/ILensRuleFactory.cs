namespace Nocturne.Abstractions.Lens
{
    public interface ILensRuleFactory
    {
        IEnumerable<ILensMutationRule> GetRules();
    }
}