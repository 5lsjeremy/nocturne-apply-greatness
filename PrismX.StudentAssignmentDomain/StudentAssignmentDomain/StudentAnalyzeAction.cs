using System.Numerics;
using PrismX.Shared.Types.Contracts.Base;
using PrismX.Shared.Types.Contracts.Context;
using PrismX.Shared.Types.Contracts.Factory;
using PrismX.Shared.Types.Contracts.States;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain
{
    /// <summary>
    /// StudentAnalyzeAction mirrors CarTripAction.
    /// It receives the typed input, builds resolved vectors,
    /// and produces PRISM result vectors.
    /// </summary>
    public sealed class StudentAnalyzeAction : IActionType
    {
        private readonly StudentAnalyzeVectorBuilder _vectorBuilder;
        private readonly IResultVectorFactory<StudentAnalyzeAction> _vectorFactory;

        public string Key => "student.analyze";

        public StudentAnalyzeAction(
            StudentAnalyzeVectorBuilder vectorBuilder,
            IResultVectorFactory<StudentAnalyzeAction> vectorFactory)
        {
            _vectorBuilder = vectorBuilder;
            _vectorFactory = vectorFactory;
        }

        public Task<IEnumerable<IResultVector<StudentAnalyzeAction>>> BuildVectorsAsync(
            StudentAnalyzeInput input,
            IActionDefinition actionDefinition,
            ITimeState timeState,
            IRandomState randomState,
            ISimulationState simulationState)
        {
            // 1. Build resolved vector context
            var resolved = _vectorBuilder.Build(
                input,
                actionDefinition,
                timeState,
                randomState,
                simulationState);

            // 2. Convert to PRISM result vector
            var resultVector = _vectorFactory.CreateFromResolved(
                direction: resolved.CurrentDirection ?? Vector3.Zero,
                magnitude: resolved.CurrentMagnitude ?? 0f,
                stability: resolved.CurrentStability ?? 0f,
                confidence: resolved.CurrentConfidence ?? 0f,
                variance: resolved.CurrentVariance ?? 0f,
                success: true,
                category: "student.analyze",
                data: new Dictionary<string, object>
                {
                    ["input"] = input
                }
            );

            // 3. Return list
            return Task.FromResult<IEnumerable<IResultVector<StudentAnalyzeAction>>>(
                new[] { resultVector }
            );
        }
    }
}