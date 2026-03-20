using PrismX.Crucible.Types.Modules.Overlays;
using PrismX.Shared.Types.Context;
using PrismX.Shared.Types.Contracts.Overlays;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Overlays
{
    public sealed class AffectiveDimensionOverlay : IVectorOverlay
    {
        public string Id => "student.affective";

        public void Apply(IResolvedVectorContext ctx, object? input)
        {
            var typed = (StudentAnalyzeInput)input!;
            var dimension = AffectiveDimensionMapper.Map(typed);

            ctx.ClusterMetadata["affective"] = dimension;
        }

        private static readonly VectorOverlay Math = new();

        public float Magnitude(float[] vector) => Math.Magnitude(vector);
        public float Dot(float[] a, float[] b) => Math.Dot(a, b);
        public float[] Normalize(float[] vector) => Math.Normalize(vector);
        public float[] Add(float[] a, float[] b) => Math.Add(a, b);
        public float[] Subtract(float[] a, float[] b) => Math.Subtract(a, b);
        public float[] Scale(float[] vector, float factor) => Math.Scale(vector, factor);
        public float[] Clamp(float[] vector, float min, float max) => Math.Clamp(vector, min, max);
        public float[] Blend(float[] a, float[] b, float weight) => Math.Blend(a, b, weight);
        public float[] WeightedAdd(float[] a, float weightA, float[] b, float weightB)
            => Math.WeightedAdd(a, weightA, b, weightB);
        public float[] Project(float[] a, float[] b) => Math.Project(a, b);
        public float AngleBetween(float[] a, float[] b) => Math.AngleBetween(a, b);
        public float[] Direction(float[] vector) => Math.Direction(vector);
        public float[] Resolve(float[] vector) => Math.Resolve(vector);
        public float AdjustStability(float stability, float modifier) => Math.AdjustStability(stability, modifier);
        public float AdjustVariance(float variance, float modifier) => Math.AdjustVariance(variance, modifier);
        public float AdjustConfidence(float confidence, float modifier) => Math.AdjustConfidence(confidence, modifier);
    }
}