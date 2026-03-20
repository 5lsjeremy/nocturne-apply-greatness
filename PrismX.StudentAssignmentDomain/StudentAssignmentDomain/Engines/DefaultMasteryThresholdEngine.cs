namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Engines
{
    public interface IMasteryThresholdEngine
    {
        string Evaluate(float masteryScore);
    }

    public sealed class DefaultMasteryThresholdEngine : IMasteryThresholdEngine
    {
        public string Evaluate(float masteryScore)
        {
            return masteryScore switch
            {
                >= 0.80f => "mastered",
                >= 0.60f => "proficient",
                >= 0.40f => "developing",
                >= 0.20f => "beginning",
                _ => "at-risk"
            };
        }
    }
}