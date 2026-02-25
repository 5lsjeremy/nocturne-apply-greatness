namespace Nocturne.Genesis.Config
{
    internal sealed class GenesisConfig
    {
        public GenesisDefaults Defaults { get; set; } = new();
    }

    internal sealed class GenesisDefaults
    {
        public bool OfflineMode { get; set; } = true;
        public string PromptSetPath { get; set; } = string.Empty;
        public string LocalizationPath { get; set; } = string.Empty;
    }
}