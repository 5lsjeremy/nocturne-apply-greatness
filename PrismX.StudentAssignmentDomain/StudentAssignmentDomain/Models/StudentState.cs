namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

public sealed class StudentState
{
    // Dynamic cognitive traits
    public float CurrentConfidence { get; set; } = 0.6f;
    public float CurrentAttention { get; set; } = 0.7f;
    public float CurrentFrustration { get; set; } = 0.2f;

    // Last outcomes
    public string LastError { get; set; } = string.Empty;
    public string LastSuccess { get; set; } = string.Empty;

    // Misconceptions that become active during simulation
    public List<string> ActiveMisconceptions { get; set; } = new();
    
    public string? LastCognitiveDimension { get; set; }
    public string? LastAffectiveDimension { get; set; }
    public string? LastSkillCategory { get; set; }
    public string? LastAssignmentType { get; set; }
    public string? LastAssignmentTopic { get; set; }
    public string? LastAssignmentDifficulty { get; set; }

}