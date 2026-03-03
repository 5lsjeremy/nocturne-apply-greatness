using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Adapters
{
    internal sealed class CopilotLlmAdapter : IGenesisLlmAdapter
    {
        private readonly IGenesisLlmClient _client;

        public CopilotLlmAdapter(IGenesisLlmClient client)
        {
            _client = client;
        }

        public async Task EvaluateClarityAsync(IConceptBuilder concept)
        {
            var prompt = $@"... clarity prompt ...";
            var json = await _client.CompleteAsync(prompt);
            // parse + concept.SetClarity(...)
        }

        public async Task GeneratePitchAsync(IConceptBuilder concept)
        {
            var prompt = $@"... pitch prompt ...";
            var json = await _client.CompleteAsync(prompt);
            // parse + concept.SetPitch(...)
        }

        public async Task InferTagsAsync(IConceptBuilder concept)
        {
            var prompt = $@"... tag prompt ...";
            var json = await _client.CompleteAsync(prompt);
            // parse + concept.SetTags(...)
        }

        public Task<string> GenerateRawAsync(string prompt)
            => _client.CompleteAsync(prompt);
    }
}