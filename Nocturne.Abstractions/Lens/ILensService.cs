using Nocturne.Abstractions.Surface; // <-- ISurfaceLogger

namespace Nocturne.Abstractions.Lens
{
    // ---------------------------
    //  PUBLIC ENTRYPOINT SERVICE
    // ---------------------------
    public interface ILensService
    {
        Task<ILensResult> RunAsync(
            ILensContext context,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<ILensQuestion>> GetQuestionsAsync(
            ILensContext context,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default);

        Task<ILensResult> ApplyPlannedUpdatesAsync(
            ILensContext context,
            IEnumerable<ILensPlannedUpdate> updates,
            ISurfaceLogger logger,
            CancellationToken cancellationToken = default);
    }
}