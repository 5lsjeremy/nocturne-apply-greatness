namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Engines
{
    public sealed class DefaultDifficultyDriftScalingEngine : IDifficultyDriftScalingEngine
    {
        public float Scale(float drift, string? difficulty)
        {
            return difficulty switch
            {
                "high" => drift * 1.25f,
                "medium" => drift * 1.10f,
                "low" => drift * 0.90f,
                _ => drift
            };
        }
    }
}