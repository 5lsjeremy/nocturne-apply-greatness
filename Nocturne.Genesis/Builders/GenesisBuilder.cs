using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Genesis.Models;
using Nocturne.Genesis.Models.Lineage;

namespace Nocturne.Genesis.Builders
{
    internal sealed class GenesisBuilder : IGenesisBuilder
    {
        private readonly IFingerprintService _fingerprints;

        public GenesisBuilder(IFingerprintService fingerprints)
        {
            _fingerprints = fingerprints;
        }

        public IStarterDeck BuildStarterDeck(
            ISurfaceArtifact seed,
            IGenesisContext context,
            IGenesisInferenceResult inference,
            string inferenceRunId)
        {
            var deck = (StarterDeck)inference.StarterDeck;

            // 1. Collect card IDs and version numbers
            var cardIds = deck.Cards.Select(c => c.Id).ToList();
            var cardVersions = deck.Cards
                .Select(c => c.Versions.Last().VersionNumber)
                .ToList();

            // 2. Compute metadata fingerprint
            var metadataFingerprint = _fingerprints.ComputeFingerprint(deck.Metadata);

            // 3. Compute deck fingerprint
            var deckFingerprint = _fingerprints.ComputeFingerprint(new
            {
                SeedId = seed.Id,
                InferenceRunId = inferenceRunId,
                CardIds = cardIds,
                CardVersions = cardVersions,
                Metadata = deck.Metadata
            });

            // 4. Attach deck lineage
            deck.Lineage = new DeckLineage
            {
                SeedId = seed.Id,
                InferenceRunId = inferenceRunId,
                CardIds = cardIds,
                CardVersionNumbers = cardVersions,
                MetadataFingerprint = metadataFingerprint,
                DeckFingerprint = deckFingerprint
            };
            
            return deck;
        }
    }
}