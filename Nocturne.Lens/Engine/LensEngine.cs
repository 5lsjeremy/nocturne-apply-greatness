//v.01 updated 26.03.18

using Nocturne.Abstractions.Lens;
using Nocturne.Lens.Abstractions.Models;
using Nocturne.Lens.Builders;

namespace Nocturne.Lens.Engine
{
    public sealed class LensEngine : ILensEngine
    {
        private readonly ILensDriftService _driftService;
        private readonly ILensQuestionService _questionService;
        private readonly ILensUpdateHeuristicService _updateService;

        public LensEngine(
            ILensDriftService driftService,
            ILensQuestionService questionService,
            ILensUpdateHeuristicService updateService)
        {
            _driftService = driftService;
            _questionService = questionService;
            _updateService = updateService;
        }

        public Task<ILensResult> ExecuteAsync(
            ILensContext context,
            CancellationToken cancellationToken = default)
        {
            var overlay = context.Overlay;

            context.Logger.Info(
                $"LensEngine executing with overlay: {overlay.Tags.Tone}/{overlay.Tags.Style}");

            var builder = new LensResultBuilder();

            // ------------------------------------------------------------
            // 1. Drift Detection
            // ------------------------------------------------------------
            var driftDiagnoses = _driftService.DetectDrift(context);

            foreach (var diagnosis in driftDiagnoses)
                builder.AddDiagnosis(diagnosis);

            // ------------------------------------------------------------
            // 2. Question Generation
            // ------------------------------------------------------------
            var questions = _questionService.GenerateQuestionsAsync(
                context, cancellationToken).Result;

            foreach (var question in questions)
                builder.AddQuestion(question);

            // ------------------------------------------------------------
            // 3. Planned Updates
            // ------------------------------------------------------------
            var updates = _updateService.ProposeUpdates(context);

            foreach (var update in updates)
                builder.AddPlannedUpdate(update);

            // ------------------------------------------------------------
            // 4. Build Final Result
            // ------------------------------------------------------------
            var result = builder.Build();

            return Task.FromResult(result);
        }
    }
}