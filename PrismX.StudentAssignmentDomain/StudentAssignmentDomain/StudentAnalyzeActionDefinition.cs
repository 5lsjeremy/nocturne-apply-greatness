using PrismX.Shared.Types.Context;
using PrismX.Shared.Types.Contracts.Context;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain
{
    public sealed record StudentAnalyzeActionDefinition : IActionDefinition
    {
        public string Key => "student.analyze";

        public string Id { get; init; } = "student.analyze";

        public Type ActionType => typeof(StudentAnalyzeAction);

        public int ExpectedVectorCount { get; init; } = 1;

        public IReadOnlyList<string> Overlays { get; init; } = Array.Empty<string>();

        public IReadOnlyList<string> Modifiers { get; init; } = Array.Empty<string>();

        public IVectorProcessingDefinition VectorDefinition { get; init; }
            = new VectorProcessingDefinition();

        public IReadOnlyList<string> Tags { get; init; } = Array.Empty<string>();
    }
}