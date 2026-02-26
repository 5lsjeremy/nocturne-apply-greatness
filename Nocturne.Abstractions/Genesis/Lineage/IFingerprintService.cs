namespace Nocturne.Abstractions.Genesis.Lineage
{
    /// <summary>
    /// Generates deterministic fingerprints for artifacts.
    /// Fingerprints allow conflict detection, replay validation, and safe merging.
    /// </summary>
    public interface IFingerprintService
    {
        string ComputeFingerprint(object artifact);
    }
}