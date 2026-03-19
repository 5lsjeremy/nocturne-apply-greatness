//v.01 updated 26.03.18
namespace Nocturne.Abstractions.Lens
{
    public interface ILensRiffCardSchema
    {
        string LensQuestionTag { get; }
        string DomainProperty { get; }
        string RelatedArtifactsProperty { get; }
        string OriginalPromptProperty { get; }
    }
}