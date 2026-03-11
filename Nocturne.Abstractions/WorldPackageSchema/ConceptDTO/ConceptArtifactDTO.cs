namespace Nocturne.Abstractions.WorldPackageSchema.ConceptDTO
{
    public sealed record ConceptArtifactsDTO
    {
        public ConceptCore Core { get; }
        public ConceptClarity Clarity { get; }
        public ConceptPitch Pitch { get; }
        public ConceptTags Tags { get; }
        public ConceptFeasibility Feasibility { get; }
        public ConceptLogs Logs { get; }

        public ConceptArtifactsDTO(
            ConceptCore core,
            ConceptClarity clarity,
            ConceptPitch pitch,
            ConceptTags tags,
            ConceptFeasibility feasibility,
            ConceptLogs logs)
        {
            Core = core;
            Clarity = clarity;
            Pitch = pitch;
            Tags = tags;
            Feasibility = feasibility;
            Logs = logs;
        }
    }
}