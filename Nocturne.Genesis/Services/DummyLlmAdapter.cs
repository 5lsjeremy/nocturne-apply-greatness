namespace Nocturne.Genesis.Services
{
    internal sealed class DummyLlmAdapter : IGenesisLlmAdapter
    {
        public string Generate(string prompt)
        {
            // MVP+ placeholder – later wired to real LLM.
            return $"[LLM_ENRICHED]: {prompt.Substring(0, System.Math.Min(prompt.Length, 200))}...";
        }
    }
}