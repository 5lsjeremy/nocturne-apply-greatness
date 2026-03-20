using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Data;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Engines;

public sealed class DefaultMasteryDriftEngine : IMasteryDriftEngine
{
    public float ComputeDrift(IMasteryDriftContext ctx)
    {
        float drift = 0f;

        // 1. Base drift from confidence
        drift += ctx.Cluster.Confidence > 0.5f
            ? MasteryDriftWeights.BasePositive
            : MasteryDriftWeights.BaseNegative;

        // 2. Cognitive dimension
        if (ctx.State.LastCognitiveDimension is string cog &&
            MasteryDriftWeights.Cognitive.TryGetValue(cog, out var cogWeight))
        {
            drift += cogWeight;
        }

        // 3. Affective dimension
        if (ctx.State.LastAffectiveDimension is string aff &&
            MasteryDriftWeights.Affective.TryGetValue(aff, out var affWeight))
        {
            drift += affWeight;
        }

        // 4. Misconceptions
        drift += ctx.State.ActiveMisconceptions.Count
                 * MasteryDriftWeights.MisconceptionPenalty;

        // 5. Assignment difficulty
        if (ctx.State.LastAssignmentDifficulty is string diff &&
            MasteryDriftWeights.Difficulty.TryGetValue(diff, out var diffWeight))
        {
            drift += diffWeight;
        }

        // Scale drift by previous mastery (prevents huge early penalties)
        float masteryScale = Math.Clamp(ctx.Cluster.Confidence + 0.1f, 0.1f, 1f);
        drift *= masteryScale;
        
        return drift;
    }
}