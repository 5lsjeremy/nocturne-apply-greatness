namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

public sealed class StudentProfile
{
    // Cognitive baselines
    public float WorkingMemory { get; set; } = 0.7f;
    public float AttentionSpan { get; set; } = 0.7f;
    public float Motivation { get; set; } = 0.8f;
    public float ConfidenceBaseline { get; set; } = 0.6f;

    // Identity / classification
    public string DisabilityProfile { get; set; } = "none";

    // Hierarchical skill map: Subject -> Course -> Unit
    public Dictionary<string, SkillSubject> Subjects { get; set; } = new();

    // Knowledge structures
    public List<string> PriorKnowledge { get; set; } = new();
    public List<string> Misconceptions { get; set; } = new();
}