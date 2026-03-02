using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.Overlays.Engines;

namespace Nocturne.Surface.Overlays.Engines.Defaults
{
    public sealed class QuestionDefault : IQuestionEngine
    {
        public IQuestionOutput Execute(IQuestionInput input)
            => new QuestionOutput();
    }
}