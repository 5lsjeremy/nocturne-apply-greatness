namespace Nocturne.Lens.Services
{
    public class LensService : ILensService
    {
        private readonly ILensEngine _engine;
        private readonly ILensMergeService _mergeService;
        private readonly ILensQuestionService _questionService;

        public Task<LensResult> RunAsync(LensContext context) =>
            _engine.ExecuteAsync(context);

        public Task<IReadOnlyList<LensQuestion>> GetQuestionsAsync(LensContext context) =>
            _questionService.GenerateQuestionsAsync(context);

        public Task<LensResult> ApplyPlannedUpdatesAsync(
            LensContext context,
            IEnumerable<LensPlannedUpdate> updates) =>
            _mergeService.ApplyAsync(context, updates);
    }
}