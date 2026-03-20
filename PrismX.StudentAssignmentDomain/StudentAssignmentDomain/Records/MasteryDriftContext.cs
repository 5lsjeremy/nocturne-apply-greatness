using PrismX.Shared.Types.Clusters;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Records;

public sealed record MasteryDriftContext : IMasteryDriftContext
{
    public ClusterBase Cluster { get; init; }
    public StudentState State { get; init; }
    public SkillUnit Unit { get; init; }
}