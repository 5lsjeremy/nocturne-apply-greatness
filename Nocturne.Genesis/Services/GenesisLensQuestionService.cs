//v.02 updated 26.03.18
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Enums;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Lens;
using Nocturne.Genesis.Models;
using Nocturne.Genesis.Models.Lineage;

namespace Nocturne.Genesis.Services
{
    internal sealed class GenesisLensQuestionService : IGenesisLensQuestionService
    {
        private readonly IRiffService _riffService;
        private readonly ILensRiffCardSchema _schema;

        public GenesisLensQuestionService(
            IRiffService riffService,
            ILensRiffCardSchema schema)
        {
            _riffService = riffService;
            _schema = schema;
        }

        public Task<ICard> RiffQuestionAsync(
            ILensQuestion question,
            ILensContext context,
            CancellationToken cancellationToken = default)
        {
            // Convert LensQuestion → temporary GenesisCard
            var tempCard = new GenesisCard
            {
                Id = question.Id,
                Name = question.Prompt,

                Tags = new List<string>
                {
                    _schema.LensQuestionTag
                },

                Properties = new Dictionary<string, object>
                {
                    [_schema.DomainProperty] = question.Domain,
                    [_schema.RelatedArtifactsProperty] = question.RelatedArtifactIds,
                    [_schema.OriginalPromptProperty] = question.Prompt
                },

                // Classification defaults
                Type = CardStatusDetails.CardType.Note,
                Origin = CardStatusDetails.CardOriginType.System,
                Status = CardStatusDetails.CardStatusType.Draft,
                ReviewState = CardStatusDetails.CardReviewState.None,
                Visibility = CardStatusDetails.CardVisibility.Internal,
                Intent = CardStatusDetails.CardIntentType.None,
                Authority = CardStatusDetails.CardAuthorityType.System,
                Confidence = CardStatusDetails.CardConfidenceLevel.Medium,
                Scope = CardStatusDetails.CardScopeType.Local,
                Stability = CardStatusDetails.CardStabilityType.Unstable,
                Energy = CardStatusDetails.CardEnergyType.Low,
                Complexity = CardStatusDetails.CardComplexityLevel.Simple,
                DependencyRole = CardStatusDetails.CardDependencyRole.None,
                State = CardStatusDetails.ArtifactState.Draft,

                Provenance = new EmptyProvenance(),
                Fingerprint = string.Empty
            };

            // Versions list is already initialized by GenesisCard
            // DO NOT assign to Versions — only mutate if needed

            // TODO: Allow Surface prompt context to influence riffing
            // context.Logger.CapturePromptContext();

            var riffed = _riffService.Riff(
                tempCard,
                contributor: "lens",
                prompt: question.Prompt);

            return Task.FromResult(riffed);
        }
    }
}