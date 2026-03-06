using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Overlays;
using Nocturne.Genesis.Engine;
using Nocturne.Genesis.Prompts;

namespace Nocturne.Genesis.Services
{
    internal sealed class GenesisPromptService : IGenesisPromptService
    {
        private readonly PromptSet _promptSet;
        private readonly PromptLocalization _localization;
        private readonly ILlmPromptBuilder _promptBuilder;
        private readonly IGenesisLlmAdapter _llm;

        private readonly bool _offlineMode;

        public GenesisPromptService(
            PromptSet promptSet,
            PromptLocalization localization,
            ILlmPromptBuilder promptBuilder,
            IGenesisLlmAdapter llm,
            bool offlineMode)
        {
            _promptSet = promptSet;
            _localization = localization;
            _promptBuilder = promptBuilder;
            _llm = llm;
            _offlineMode = offlineMode;
        }

        public async Task RunMvpLoopAsync(IGenesisContext context, IOverlayTags? tags = null)
        {
            // Overlay tags: explicit param overrides context
            var effectiveTags = tags ?? context.OverlayTags;

            foreach (var q in _promptSet.Questions.OrderBy(q => q.Order))
            {
                // -----------------------------
                // OFFLINE PROMPT (builder-facing)
                // -----------------------------
                var flavoredPrompt = PromptMerger.ApplyLocalization(q.OfflinePrompt, _localization);

                if (effectiveTags != null)
                {
                    flavoredPrompt = $"{flavoredPrompt}\n\n[overlay-tone:{effectiveTags.Tone}]";
                }

                context.Answers[q.Id] = new
                {
                    Prompt = flavoredPrompt,
                    Response = (string?)null
                };

                if (_offlineMode)
                    continue;

                // -----------------------------
                // LLM PROMPT (world-enrichment)
                // -----------------------------
                var llmPrompt = _promptBuilder.Build(q, context, _localization);

                if (effectiveTags != null)
                {
                    llmPrompt = $"{llmPrompt}\n\n[overlay-density:{effectiveTags.Density}]";
                }

                // -----------------------------
                // RAW LLM RESPONSE
                // -----------------------------
                var enriched = await _llm.GenerateRawAsync(llmPrompt);

                context.Answers[$"{q.Id}_llm"] = enriched;
            }
        }
    }
}