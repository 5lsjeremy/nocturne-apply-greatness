using PrismX.DomainSDK.Kit.Inputs;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain;

public sealed class StudentAnalyzeInput : PrismDefaultInput
{
    public string AssignmentText { get; set; } = string.Empty;
    public string StudentResponse { get; set; } = string.Empty;

    // identifies the exact unit being assessed
    public string UnitSlug { get; set; } = string.Empty;
}