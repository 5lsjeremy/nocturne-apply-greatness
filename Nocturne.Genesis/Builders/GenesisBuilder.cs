using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Abstractions.Overlays;
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

        // UPDATED SIGNATURE — now matches the interface
        public IStarterDeck BuildStarterDeck(
            ISurfaceArtifact seed,
            IGenesisContext context,
            IGenesisInferenceResult inference,
            string inferenceRunId,
            IOverlayTags? tags = null)
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
                Metadata = deck.Metadata,
                OverlayTone = tags?.Tone,
                OverlayDensity = tags?.Density,
                OverlayRisk = tags?.Risk
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

            // 5. Apply overlay metadata (optional but useful)
            if (tags != null)
            {
                deck.Metadata["overlay-tone"] = tags.Tone;
                deck.Metadata["overlay-density"] = tags.Density;
                deck.Metadata["overlay-risk"] = tags.Risk;
            }

            return deck;
        }
    }
}