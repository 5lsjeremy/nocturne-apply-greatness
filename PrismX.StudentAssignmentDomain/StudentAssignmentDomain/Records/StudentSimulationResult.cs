using System.Numerics;
using PrismX.Shared.Types.Clusters;
using PrismX.Shared.Types.Definitions.Results;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Records;

public sealed record StudentSimulationResult
{
    /// <summary>
    /// The raw PRISM result returned by the engine.
    /// Contains the resolved vector context, clusters, metadata, etc.
    /// </summary>
    public PrismActionResult<StudentAnalyzeAction> PrismResult { get; init; }

    /// <summary>
    /// The updated student cognitive/affective state.
    /// </summary>
    public StudentState UpdatedState { get; init; }

    /// <summary>
    /// The cluster PRISM resolved to.
    /// </summary>
    public ClusterBase Cluster { get; init; }

    /// <summary>
    /// Convenience: cluster physics.
    /// </summary>
    public float Confidence => Cluster.Confidence;
    public float Stability  => Cluster.Stability;
    public float Variance   => Cluster.Variance;
    public float Polarity   => Cluster.Polarity;
    public Vector3 Centroid => Cluster.Centroid;

    /// <summary>
    /// Convenience: tags PRISM attached to the cluster.
    /// </summary>
    public IReadOnlyList<string> Tags => Cluster.Tags;

    /// <summary>
    /// Convenience: metadata PRISM attached to the cluster.
    /// </summary>
    public IReadOnlyDictionary<string, object> Metadata => 
        (IReadOnlyDictionary<string, object>)Cluster.Metadata;
}