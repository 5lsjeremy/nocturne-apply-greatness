namespace Nocturne.Genesis.Config
{
    internal sealed class GenesisConfig
    {
        public GenesisDefaults Defaults { get; set; } = new();
        public GenesisLlmConfig Llm { get; set; } = new();
    }
}