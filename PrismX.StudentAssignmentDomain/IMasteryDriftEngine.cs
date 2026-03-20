namespace PrismX.StudentAssignmentDomain
{
    public interface IMasteryDriftEngine
    {
        float ComputeDrift(IMasteryDriftContext context);
    }
    public interface IMasteryProgressionEngine
    {
        float ComputeProgression(IMasteryDriftContext context);
    }
    public interface IDifficultyDriftScalingEngine
    {
        float Scale(float drift, string? difficulty);
    }
}