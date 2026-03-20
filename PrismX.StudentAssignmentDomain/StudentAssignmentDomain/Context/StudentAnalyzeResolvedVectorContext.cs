using System.Numerics;
using PrismX.Shared.Types.Context;
using PrismX.Shared.Types.Contracts.Context;
using PrismX.Shared.Types.Contracts.States;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Context
{
    public sealed class StudentAnalyzeResolvedVectorContext : IResolvedVectorContext
    {
        public StudentAnalyzeResolvedVectorContext(
            IActionDefinition actionDefinition,
            ITimeState timeState,
            IRandomState randomState,
            ISimulationState simulationState)
        {
            ActionDefinition = actionDefinition;
            TimeState = timeState;
            RandomState = randomState;
            SimulationState = simulationState;

            NarrativeContext = new NarrativeContext();
            ClusterMetadata = new Dictionary<string, object>();
        }

        public Vector3? CurrentDirection { get; set; }
        public float? CurrentMagnitude { get; set; }
        public float? CurrentStability { get; set; }
        public float? CurrentConfidence { get; set; }
        public float? CurrentVariance { get; set; }

        public NarrativeContext NarrativeContext { get; set; }

        public IActionDefinition ActionDefinition { get; }
        public ITimeState TimeState { get; }
        public IRandomState RandomState { get; }
        public ISimulationState SimulationState { get; }

        public IDictionary<string, object> ClusterMetadata { get; }
    }
}