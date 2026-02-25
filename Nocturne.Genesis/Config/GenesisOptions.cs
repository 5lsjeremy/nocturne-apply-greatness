using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Config;

internal sealed class GenesisOptions : IGenesisOptions
{
    public bool? OfflineMode { get; set; }
    public string? PromptSetPath { get; set; }
    public string? LocalizationPath { get; set; }
    public bool? DarkMode { get; set; }
}