namespace Nocturne.Abstractions.Genesis.Lineage
{
    /// <summary>
    /// Manages version chains for artifacts.
    /// Ensures meaningful version bumps and immutable version history.
    /// </summary>
    public interface IVersioningService
    {
        IVersionInfo CreateInitialVersion(string author, string origin, object artifact);
        IVersionInfo CreateNextVersion(IVersionInfo previous, string author, string origin, object artifact);
    }
}