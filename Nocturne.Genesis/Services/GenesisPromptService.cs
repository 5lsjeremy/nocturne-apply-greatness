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
            // ❌ NO LONGER ALLOWED:
            // var concrete = (GenesisContext)context;
            // concrete.OverlayTags = tags;

            // Overlay tags come from the context constructor.
            // Use the effective tags (method param overrides context if provided).
            var effectiveTags = tags ?? context.OverlayTags;

            foreach (var q in _promptSet.Questions.OrderBy(q => q.Order))
            {
                var flavoredPrompt = PromptMerger.ApplyLocalization(q.OfflinePrompt, _localization);

                // Apply overlay tone/density/etc. if present
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

                var llmPrompt = _promptBuilder.Build(q, context, _localization);

                // Apply overlay tags to LLM prompt
                if (effectiveTags != null)
                {
                    llmPrompt = $"{llmPrompt}\n\n[overlay-density:{effectiveTags.Density}]";
                }

                var enriched = await _llm.GenerateRawAsync(llmPrompt);

                context.Answers[$"{q.Id}_llm"] = enriched;
            }
        }
    }
}