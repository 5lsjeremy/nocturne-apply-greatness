//v.01 updated 26.03.18
namespace Nocturne.Abstractions.Lens
{
    public interface ILensService
    {
        Task<ILensResult> RunAsync(
            ILensContext context,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<ILensQuestion>> GetQuestionsAsync(
            ILensContext context,
            CancellationToken cancellationToken = default);

        Task<ILensResult> ApplyPlannedUpdatesAsync(
            ILensContext context,
            IEnumerable<ILensPlannedUpdate> updates,
            CancellationToken cancellationToken = default);
    }
}