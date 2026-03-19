//v.01 updated 26.03.18

namespace Nocturne.Abstractions.Lens;

public interface ILensEngine
{
    Task<ILensResult> ExecuteAsync(
        ILensContext context,
        CancellationToken cancellationToken = default);
}