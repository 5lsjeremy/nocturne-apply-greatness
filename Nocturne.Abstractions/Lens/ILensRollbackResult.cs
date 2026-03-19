namespace Nocturne.Abstractions.Lens
{
    public interface ILensRollbackResult
    {
        ILensContext RestoredContext { get; }
        ILensResult RestoredResult { get; }
        ILensVersionInfo VersionInfo { get; }
    }
}