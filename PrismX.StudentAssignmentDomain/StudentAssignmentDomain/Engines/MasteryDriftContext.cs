using PrismX.Shared.Types.Clusters;
using PrismX.Shared.Types.Context;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Engines
{
    public sealed class MasteryDriftContext : IMasteryDriftContext
    {
        public ClusterBase Cluster { get; init; }
        public StudentState State { get; init; }
        public SkillUnit Unit { get; init; }

        // Optional: your domain state (not part of the interface)
        public StudentAssignmentState DomainState { get; }

        public IResolvedVectorContext VectorContext { get; }

        public MasteryDriftContext(
            IResolvedVectorContext vectorContext,
            ClusterBase cluster,
            StudentState state,
            SkillUnit unit,
            StudentAssignmentState domainState)
        {
            VectorContext = vectorContext;
            Cluster = cluster;
            State = state;
            Unit = unit;
            DomainState = domainState;
        }
    }
}