//v.01 updated 26.03.18

using Nocturne.Abstractions.Lens;

namespace Nocturne.Lens.Services
{
    internal sealed class LensRiffCardSchema : ILensRiffCardSchema
    {
        public string LensQuestionTag => "lens-question";
        public string DomainProperty => "domain";
        public string RelatedArtifactsProperty => "relatedArtifacts";
        public string OriginalPromptProperty => "originalPrompt";
    }
}