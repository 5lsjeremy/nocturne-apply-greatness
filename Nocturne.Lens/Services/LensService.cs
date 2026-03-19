//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;

namespace Nocturne.Lens.Services
{
    public sealed class LensService : ILensService
    {
        private readonly ILensEngine _engine;
        private readonly ILensMergeService _mergeService;
        private readonly ILensQuestionService _questionService;

        public LensService(
            ILensEngine engine,
            ILensMergeService mergeService,
            ILensQuestionService questionService)
        {
            _engine = engine;
            _mergeService = mergeService;
            _questionService = questionService;
        }

        public Task<ILensResult> RunAsync(
            ILensContext context,
            CancellationToken cancellationToken = default) =>
            _engine.ExecuteAsync(context, cancellationToken);

        public Task<IReadOnlyList<ILensQuestion>> GetQuestionsAsync(
            ILensContext context,
            CancellationToken cancellationToken = default) =>
            _questionService.GenerateQuestionsAsync(context, cancellationToken);

        public Task<ILensResult> ApplyPlannedUpdatesAsync(
            ILensContext context,
            IEnumerable<ILensPlannedUpdate> updates,
            CancellationToken cancellationToken = default) =>
            _mergeService.ApplyAsync(context, updates, cancellationToken);
    }
}