using System.Numerics;
using PrismX.Shared.Types.Clusters;
using PrismX.Shared.Types.Diagnostics;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Clusters
{
    public sealed record StudentCluster : ClusterBase
    {
        public StudentCluster(
            Vector3 centroid,
            float confidence,
            float stability,
            float variance,
            float polarity,
            IReadOnlyList<string> tags,
            IDictionary<string, object> metadata)
        {
            Centroid = centroid;
            Confidence = confidence;
            Stability = stability;
            Variance = variance;
            Polarity = polarity;
            Tags = tags;
            Metadata = metadata;
            Provenance = new Provenance();
        }
    }
}