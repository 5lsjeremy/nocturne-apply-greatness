using Nocturne.Abstractions.WorldPackageSchema.ArtifactsDTO;
using Nocturne.Abstractions.WorldPackageSchema.SparksDTO;
using Nocturne.Genesis.LlmDTO;
using Nocturne.Genesis.Utilities;
using Nocturne.Surface.Diagnostics;

namespace Nocturne.Genesis.Assemblers
{
    public sealed class SparkAssembler
    {
        public SparkArtifact Assemble(
            LlmSparkResponse llm,
            string sparkId,
            string sparkSlug,
            string parentCardId,
            string parentCardSlug,
            string parentDomainId,
            string parentDomainSlug,
            SurfaceLogger logger)
        {
            //
            // Load templates
            //
            var definitionTemplate = TemplateLoader.LoadTemplate<SparkDefinition>("Sparks/definition.json");
            var metadataTemplate   = TemplateLoader.LoadTemplate<SparkMetadata>("Sparks/metadata.json");
            var discoveryTemplate  = TemplateLoader.LoadTemplate<SparkDiscovery>("Sparks/discovery.json");
            var effectsTemplate    = TemplateLoader.LoadTemplate<SparkEffects>("Sparks/effects.json");
            var logsTemplate       = TemplateLoader.LoadTemplate<SparkLogs>("Sparks/logs.json");

            //
            // Definition
            //
            var definition = definitionTemplate with
            {
                Id = sparkId,
                Slug = sparkSlug,
                ParentCardId = parentCardId,
                ParentCardSlug = parentCardSlug,
                Prompt = llm.Prompt,
                SparkType = llm.SparkType,
                Tags = llm.Tags.ToList(),
                OverlayEligible = llm.OverlayEligible
            };

            //
            // Metadata
            //
            var metadata = metadataTemplate with
            {
                Title = llm.Title,
                Description = llm.Description,
                Category = llm.Category,
                Keywords = llm.Keywords.ToList(),
                Lore = llm.Lore,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };

            //
            // Discovery
            //
            var discovery = discoveryTemplate with
            {
                Source = llm.Source,
                Trigger = llm.Trigger,
                Context = llm.Context,
                Evidence = llm.Evidence.ToList()
            };

            //
            // Effects (full SparkEffect model)
            //
            var effects = effectsTemplate with
            {
                Identity = effectsTemplate.Identity with
                {
                    EffectId = llm.EffectId,
                    EffectSlug = llm.EffectSlug,
                    SparkId = sparkId,
                    ParentCardId = parentCardId,
                    ParentCardSlug = parentCardSlug,
                    ParentDomainId = parentDomainId,
                    ParentDomainSlug = parentDomainSlug
                },

                Type = llm.Type,

                Tags = new SparkEffectTags(
                    llm.InheritedTags.ToList(),
                    llm.GeneratedTags.ToList(),
                    llm.DomainTags.ToList()
                ),

                Triggers = new SparkEffectTriggers(
                    llm.ActivationStates.ToList(),
                    llm.SuppressionStates.ToList(),
                    llm.ModificationStates.ToList()
                ),

                Modifiers = new SparkEffectModifiers(
                    llm.AllowedModifiers.ToList(),
                    llm.ForbiddenModifiers.ToList(),
                    llm.OverlayModifiers.ToList()
                ),

                Accumulation = new SparkEffectAccumulation(
                    llm.StabilityContribution,
                    llm.PressureContribution,
                    llm.DriftContribution,
                    llm.AccumulationCategory
                ),

                Lifespan = new SparkEffectLifespan(
                    llm.DurationType,
                    llm.Duration,
                    DateTime.UtcNow,
                    llm.ExpiresAt
                ),

                State = new SparkEffectState(
                    llm.CurrentState,
                    DateTime.UtcNow
                ),

                Strength = new SparkEffectStrength(
                    llm.BaseStrength,
                    llm.CurveType,
                    llm.CurveParameters
                ),

                Dependencies = new SparkEffectDependencies(
                    llm.RequiredEffects.ToList(),
                    llm.ConflictingEffects.ToList(),
                    llm.RequiredDomainStates.ToList(),
                    llm.RequiredCardStates.ToList()
                ),

                Visibility = new SparkEffectVisibility(
                    llm.VisibleToDesigner,
                    llm.VisibleToSimulation,
                    llm.VisibleToOverlays,
                    llm.VisibleInStarterPack
                ),

                Evidence = new SparkEffectEvidence(
                    llm.SimulationLogs.ToList(),
                    llm.DesignerNotes.ToList(),
                    llm.ObservedBehaviors.ToList()
                )
            };

            //
            // Logs
            //
            var logs = logsTemplate with
            {
                Entries = logger.Entries
                    .Select(e => new SparkLogEntry(
                        e.Timestamp,
                        e.Message,
                        e.Source
                    ))
                    .ToList()
            };

            //
            // Final artifact
            //
            return new SparkArtifact(
                definition,
                metadata,
                discovery,
                effects,
                logs
            );
        }
    }
}