namespace Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;

public sealed record LlmPresentationResponse
{
    public string? Title { get; init; }
    public string? Subtitle { get; init; }
    public string? Overview { get; init; }
    public List<string>? Pillars { get; init; }
    public List<string>? RecommendedNextSteps { get; init; }
}