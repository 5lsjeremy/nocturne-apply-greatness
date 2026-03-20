using PrismX.Shared.Types.Context;
using PrismX.Shared.Types.Contracts.Context;
using PrismX.Shared.Types.Contracts.Initializer;
using PrismX.Shared.Types.Contracts.States;
using PrismX.Shared.Types.Factories.Contracts;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain
{
    public sealed class StudentAssignmentRouter : IActionRouter
    {
        private readonly INarrativeContextFactory _narrativeFactory;

        public StudentAssignmentRouter(INarrativeContextFactory narrativeFactory)
        {
            _narrativeFactory = narrativeFactory;
        }

        public bool CanHandle(IActionDefinition action)
            => action?.Id == "student.analyze";

        public object? ResolveInput(
            IActionDefinition action,
            ITimeState time,
            IRandomState random,
            ISimulationState sim,
            object input)
        {
            if (input is not StudentAnalyzeInput typed)
                throw new InvalidOperationException(
                    $"Expected StudentAnalyzeInput but got {input?.GetType().Name}");

            return typed;
        }

        public Task<NarrativeContext> BuildNarrativeAsync(
            IActionDefinition action,
            ITimeState time,
            IRandomState random,
            ISimulationState sim,
            object domainInput)
        {
            var narrative = _narrativeFactory.Create(
                emotionalTags: [],
                situationalTags: [],
                agentFlags: [],
                worldFlags: [],
                metadata: new Dictionary<string, object>()
            );

            return Task.FromResult(narrative);
        }

        public IReadOnlyList<string> GetOverlayKeys(IActionDefinition action)
            => new[] { "TagRoutingOverlay", "TagMetadataOverlay" };

        public IReadOnlyList<string> GetModifierKeys(IActionDefinition action)
            => Array.Empty<string>();

        public IReadOnlyList<string> GetClusterTags(IActionDefinition action)
            => new[] { "student", "assignment", "analysis" };
    }
}