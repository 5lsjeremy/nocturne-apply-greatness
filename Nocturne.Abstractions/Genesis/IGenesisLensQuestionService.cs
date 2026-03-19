//v.01 updated 26.03.18
using Nocturne.Abstractions.Lens;
using Nocturne.Abstractions.Genesis;

namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisLensQuestionService
    {
        /// <summary>
        /// Convert a LensQuestion into a temporary Genesis card,
        /// riff it using the Genesis LLM pipeline,
        /// and return the riffed card.
        /// </summary>
        Task<ICard> RiffQuestionAsync(
            ILensQuestion question,
            ILensContext context,
            CancellationToken cancellationToken = default);
    }
}