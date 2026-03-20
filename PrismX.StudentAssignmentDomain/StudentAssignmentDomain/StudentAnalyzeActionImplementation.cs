using PrismX.Shared.Types.Actions.Implementations;
using PrismX.Shared.Types.Contracts.Context;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain;

public sealed class StudentAnalyzeActionImplementation 
    : IActionImplementation<StudentAnalyzeAction>
{
    public Task<object?> ExecuteAsync(
        IActionDefinition action,
        object? domainInput,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(domainInput);
    }
}