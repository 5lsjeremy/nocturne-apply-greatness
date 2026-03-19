//v.01 updated 26.03.18

namespace Nocturne.Abstractions.Lens;

public interface ILensQuestionService
{
    Task<IReadOnlyList<ILensQuestion>> GenerateQuestionsAsync(
        ILensContext context,
        CancellationToken cancellationToken = default);
}