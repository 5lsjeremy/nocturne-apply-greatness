namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Engines
{
    public sealed class DefaultMasteryProgressionEngine :IMasteryProgressionEngine
    {
        public float ComputeProgression(IMasteryDriftContext ctx)
        {
            float progression = 0f;

            // Bloom’s taxonomy weighting
            if (ctx.State.LastCognitiveDimension is string cog)
            {
                progression += cog switch
                {
                    "create" => 0.15f,
                    "evaluate" => 0.12f,
                    "analyze" => 0.10f,
                    "apply" => 0.07f,
                    "understand" => 0.04f,
                    "remember" => 0.02f,
                    _ => 0f
                };
            }

            // Affective boost
            if (ctx.State.LastAffectiveDimension == "confidence")
                progression += 0.05f;

            // Misconception penalty
            progression -= ctx.State.ActiveMisconceptions.Count * 0.10f;

            // Difficulty scaling
            if (ctx.State.LastAssignmentDifficulty == "high")
                progression += 0.10f;
            else if (ctx.State.LastAssignmentDifficulty == "medium")
                progression += 0.05f;

            return progression;
        }
    }
}