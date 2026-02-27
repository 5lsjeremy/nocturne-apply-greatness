using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Genesis.Models.Lineage;

namespace Nocturne.Genesis.Services.Lineage
{
    internal sealed class VersioningService : IVersioningService
    {
        public IVersionInfo CreateInitialVersion(
            string author,
            string origin,
            object artifact)
        {
            return new CardVersionInfo
            {
                VersionNumber = 1,
                Timestamp = DateTime.UtcNow,
                Author = author,
                Origin = origin,
                Notes = "initial",
            };
        }

        public IVersionInfo CreateNextVersion(
            IVersionInfo previous,
            string author,
            string origin,
            object artifact)
        {
            return new CardVersionInfo
            {
                VersionNumber = previous.VersionNumber + 1,
                Timestamp = DateTime.UtcNow,
                Author = author,
                Origin = origin,
                Notes = $"supersedes v{previous.VersionNumber}"
            };
        }
    }
}