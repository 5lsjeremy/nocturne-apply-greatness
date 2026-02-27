namespace Nocturne.Genesis.Models.Lineage
{
    public sealed class ProvenanceAction
    {
        public string Action { get; init; } = string.Empty;   // "approved", "rejected", "proposed-edit"
        public string Actor { get; init; } = string.Empty;    // approver or contributor
        public int PreviousVersion { get; init; }             // version number before the action
        public string? Reason { get; init; }                  // rejection reason
        public string? Prompt { get; init; }                  // edit prompt
        public DateTime Timestamp { get; init; }              // when the action occurred
    }
}