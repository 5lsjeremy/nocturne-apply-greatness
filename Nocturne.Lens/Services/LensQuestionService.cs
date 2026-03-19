//v.01 updated 26.03.18
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Lens.Enums;
using Nocturne.Lens.Abstractions.Models;

namespace Nocturne.Lens.Services;

public sealed class LensQuestionService : ILensQuestionService
{
    private readonly IGenesisLensQuestionService _genesis;

    public LensQuestionService(IGenesisLensQuestionService genesis)
    {
        _genesis = genesis;
    }

    public async Task<IReadOnlyList<ILensQuestion>> GenerateQuestionsAsync(
        ILensContext context,
        CancellationToken cancellationToken = default)
    {
        context.Logger.Info("Generating Lens questions via Genesis LLM riffing.");

        // TODO: For each overlay.QuestionBiasTag:
        // - Create a LensQuestion
        // - Riff it through Genesis
        // - Interpret the riffed card into a LensQuestion or LensPlannedUpdate

        var questions = new List<ILensQuestion>();

        foreach (var tag in context.Overlay.QuestionBiasTags)
        {
            var q = new LensQuestion
            {
                Prompt = $"How does this relate to {tag}?",
                Choices = Array.Empty<ILensChoice>(),
                Domain = string.Empty,
                RelatedArtifactIds = Array.Empty<string>(),
                SourcePass = LensPassType.QuestionGeneration
            };

            var riffed = await _genesis.RiffQuestionAsync(q, context, cancellationToken);

            // TODO: Interpret riffed card → LensQuestion or LensPlannedUpdate
            questions.Add(q);
        }

        return questions;
    }
}