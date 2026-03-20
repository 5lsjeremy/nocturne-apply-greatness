using PrismX.Shared.Types.Clusters;
using PrismX.Shared.Types.Contracts.States;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models
{
    public sealed class SimulationState : ISimulationState
    {
        private IReadOnlyList<ClusterBase> _clusters = new List<ClusterBase>();

        public long Version { get; private set; }
        public IReadOnlyDictionary<string, object>? Data { get; }

        public IReadOnlyList<ClusterBase> Clusters
        {
            get => _clusters;
            set
            {
                _clusters = value;
                Version++;
            }
        }

        public SimulationState()
        {
            Data = new Dictionary<string, object>();
        }
    }
}