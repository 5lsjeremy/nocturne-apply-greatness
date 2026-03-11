using Nocturne.Abstractions.Overlays;
using Nocturne.Abstractions.WorldPackageSchema.OverlayDTO;

namespace Nocturne.Genesis.Assemblers
{
    public sealed class OverlayAssembler
    {
        public OverlayDefinitionDTO Assemble(LlmOverlayResponse llm)
        {
            return new OverlayDefinitionDTO
            {
                Name = llm.Name,
                Description = llm.Description,

                ToneShift = llm.ToneShift,
                DensityShift = llm.DensityShift,
                StyleShift = llm.StyleShift,
                WorldTypeShift = llm.WorldTypeShift,
                RiskShift = llm.RiskShift,

                ActivationTags = llm.ActivationTags.ToList(),

                Timestamp = DateTime.UtcNow
            };
        }
    }
}