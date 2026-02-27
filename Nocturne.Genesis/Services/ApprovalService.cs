using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Enums;
using Nocturne.Abstractions.Genesis.Lineage;
using Nocturne.Genesis.Models;

namespace Nocturne.Genesis.Services
{
    internal sealed class ApprovalService : IApprovalService
    {
        private readonly IVersioningService _versioning;
        private readonly IProvenanceService _provenance;
        private readonly IFingerprintService _fingerprints;

        public ApprovalService(
            IVersioningService versioning,
            IProvenanceService provenance,
            IFingerprintService fingerprints)
        {
            _versioning = versioning;
            _provenance = provenance;
            _fingerprints = fingerprints;
        }

        public void Approve(ICard card, string approver)
        {
            var concrete = (GenesisCard)card;
            var previous = card.Versions.Last();

            var version = _versioning.CreateNextVersion(
                previous,
                author: approver,
                origin: "approval",
                artifact: card
            );

            concrete.Versions.Add(version);
            concrete.Fingerprint = _fingerprints.ComputeFingerprint(card);
            concrete.State = CardStatusDetails.ArtifactState.Approved;

            _provenance.AppendAction(
                concrete.Provenance,
                action: "approved",
                actor: approver,
                previousVersion: previous.VersionNumber
            );
        }

        public void Reject(ICard card, string approver, string reason)
        {
            var concrete = (GenesisCard)card;
            var previous = card.Versions.Last();

            var version = _versioning.CreateNextVersion(
                previous,
                author: approver,
                origin: "rejection",
                artifact: card
            );

            concrete.Versions.Add(version);

            _provenance.AppendAction(
                concrete.Provenance,
                action: "rejected",
                actor: approver,
                previousVersion: previous.VersionNumber,
                reason: reason
            );
        }

        public ICard ProposeEdit(ICard card, string contributor, string prompt)
        {
            var concrete = (GenesisCard)card;
            var previous = card.Versions.Last();

            var version = _versioning.CreateNextVersion(
                previous,
                author: contributor,
                origin: "proposed-edit",
                artifact: card
            );

            concrete.Versions.Add(version);
            concrete.State = CardStatusDetails.ArtifactState.Draft;
            concrete.Fingerprint = _fingerprints.ComputeFingerprint(card);

            _provenance.AppendAction(
                concrete.Provenance,
                action: "proposed-edit",
                actor: contributor,
                previousVersion: previous.VersionNumber,
                prompt: prompt
            );

            return concrete;
        }
    }
}