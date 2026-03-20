using PrismX.Shared.Types.Clusters;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

namespace PrismX.StudentAssignmentDomain
{
    public interface IMasteryDriftContext
    {
        ClusterBase Cluster { get; init; }
        StudentState State { get; init; }
        SkillUnit Unit { get; init; }
    }
}