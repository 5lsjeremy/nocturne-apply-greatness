using Nocturne.Abstractions.Genesis;
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

    public void RunMvpLoop(IGenesisContext context)
    {
        var concrete = (GenesisContext)context;

        foreach (var q in _promptSet.Questions.OrderBy(q => q.Order))
        {
            var flavoredPrompt = PromptMerger.ApplyLocalization(q.OfflinePrompt, _localization);

            concrete.Answers[q.Id] = new
            {
                Prompt = flavoredPrompt,
                Response = (string?)null
            };

            if (_offlineMode)
                continue;

            var llmPrompt = _promptBuilder.Build(q, concrete, _localization);
            var enriched = _llm.Generate(llmPrompt);

            concrete.Answers[$"{q.Id}_llm"] = enriched;
        }
    }
}