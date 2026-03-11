using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;
using System.Text.Json;
using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Adapters
{
    internal sealed class GeminiLlmAdapter : IGenesisWorldLlmAdapter
    {
        private readonly IGenesisLlmClient _client;

        public GeminiLlmAdapter(IGenesisLlmClient client)
        {
            _client = client;
        }

        //
        // DOMAIN
        //
        public async Task<LlmDomainResponse> GenerateDomainAsync(
            IGenesisContext context,
            IOverlayTags? tags,
            CancellationToken ct = default)
        {
            var prompt = context.BuildDomainPrompt(tags);
            var json = await _client.CompleteAsync(prompt);
            return JsonSerializer.Deserialize<LlmDomainResponse>(json)
                   ?? throw new InvalidOperationException("Invalid domain JSON.");
        }

        //
        // CONCEPT
        //
        public async Task<LlmConceptResponse> GenerateConceptAsync(
            IGenesisContext context,
            IOverlayTags? tags,
            CancellationToken ct = default)
        {
            var prompt = context.BuildConceptPrompt(tags);
            var json = await _client.CompleteAsync(prompt);
            return JsonSerializer.Deserialize<LlmConceptResponse>(json)
                   ?? throw new InvalidOperationException("Invalid concept JSON.");
        }

        //
        // CARD
        //
        public async Task<LlmCardResponse> GenerateCardAsync(
            IGenesisContext context,
            IOverlayTags? tags,
            CancellationToken ct = default)
        {
            var prompt = context.BuildCardPrompt(tags);
            var json = await _client.CompleteAsync(prompt);
            return JsonSerializer.Deserialize<LlmCardResponse>(json)
                   ?? throw new InvalidOperationException("Invalid card JSON.");
        }

        //
        // STARTER DECK
        //
        public async Task<LlmStarterDeckResponse> GenerateStarterDeckAsync(
            IGenesisContext context,
            IOverlayTags? tags,
            CancellationToken ct = default)
        {
            var prompt = context.BuildStarterDeckPrompt(tags);
            var json = await _client.CompleteAsync(prompt);
            return JsonSerializer.Deserialize<LlmStarterDeckResponse>(json)
                   ?? throw new InvalidOperationException("Invalid starter deck JSON.");
        }

        //
        // PRESENTATION
        //
        public async Task<LlmPresentationResponse> GeneratePresentationAsync(
            IGenesisContext context,
            IOverlayTags? tags,
            CancellationToken ct = default)
        {
            var prompt = context.BuildPresentationPrompt(tags);
            var json = await _client.CompleteAsync(prompt);
            return JsonSerializer.Deserialize<LlmPresentationResponse>(json)
                   ?? throw new InvalidOperationException("Invalid presentation JSON.");
        }

        //
        // RAW
        //
        public Task<string> GenerateRawAsync(string prompt, CancellationToken ct = default)
            => _client.CompleteAsync(prompt);
    }
}