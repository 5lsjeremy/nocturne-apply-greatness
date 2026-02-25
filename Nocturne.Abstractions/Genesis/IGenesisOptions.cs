namespace Nocturne.Abstractions.Genesis;

public interface IGenesisOptions
{
    bool? OfflineMode { get; }
    string? PromptSetPath { get; }
    string? LocalizationPath { get; }
    bool? DarkMode { get; } // NEW
}