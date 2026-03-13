namespace Nocturne.Abstractions.WorldPackageSchema.SparksDTO
{
    public sealed record SparkEffectIdentity(
        string EffectId,
        string EffectSlug,
        string SparkId,
        string ParentCardId,
        string ParentCardSlug,
        string ParentDomainId,
        string ParentDomainSlug
    );
}