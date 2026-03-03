using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Overlays;
using Nocturne.Genesis.Engine;
using Nocturne.Genesis.Prompts;

namespace Nocturne.Genesis.Services;

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

    // ORIGINAL SIGNATURE (kept for backward compatibility)
    public void RunMvpLoop(IGenesisContext context)
        => RunMvpLoop(context, null);

    // NEW OVERLAY-AWARE SIGNATURE
    public void RunMvpLoop(IGenesisContext context, IOverlayTags? tags = null)
    {
        var concrete = (GenesisContext)context;

        // Attach overlay tags to context
        concrete.OverlayTags = tags;

        foreach (var q in _promptSet.Questions.OrderBy(q => q.Order))
        {
            var flavoredPrompt = PromptMerger.ApplyLocalization(q.OfflinePrompt, _localization);

            // Apply overlay tone/density/etc. if present
            if (tags != null)
            {
                flavoredPrompt = $"{flavoredPrompt}\n\n[overlay-tone:{tags.Tone}]";
            }

            concrete.Answers[q.Id] = new
            {
                Prompt = flavoredPrompt,
                Response = (string?)null
            };

            if (_offlineMode)
                continue;

            var llmPrompt = _promptBuilder.Build(q, concrete, _localization);

            // Apply overlay tags to LLM prompt
            if (tags != null)
            {
                llmPrompt = $"{llmPrompt}\n\n[overlay-density:{tags.Density}]";
            }

            var enriched = _llm.Generate(llmPrompt);

            concrete.Answers[$"{q.Id}_llm"] = enriched;
        }
    }
}