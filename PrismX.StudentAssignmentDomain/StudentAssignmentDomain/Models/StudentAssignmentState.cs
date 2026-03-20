namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models
{
    public sealed class StudentAssignmentState
    {
        public float MasteryScore { get; set; } = 0.0f;
        public string? MasteryCategory { get; set; }

        public string? LastCognitiveDimension { get; set; }
        public string? LastAffectiveDimension { get; set; }
        public string? LastAssignmentDifficulty { get; set; }
        public string? LastDisabilityProfile { get; set; }

        public HashSet<string> ActiveMisconceptions { get; } = new();
    }
}