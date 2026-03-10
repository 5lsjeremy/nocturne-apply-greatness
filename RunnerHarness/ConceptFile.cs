using System.Text.Json.Serialization;

namespace RunnerHarness;

public sealed class ConceptFile
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("worldConcept")]
    public string? WorldConcept { get; set; }
}