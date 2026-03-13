namespace Nocturne.Genesis.Config
{
    public sealed class GenesisLlmConfig
    {
        public string Endpoint { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;

        public string ScaffoldModel { get; set; } = string.Empty;
        public string RefineModel { get; set; } = string.Empty;
        public string SynthesisModel { get; set; } = string.Empty;
        public string PremiumModel { get; set; } = string.Empty;
    }
}