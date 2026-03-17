namespace Nocturne.Abstractions.Lens
{
    public interface ILensQuestion
    {
        string Id { get; }
        string Prompt { get; }
        IReadOnlyList<ILensChoice> Choices { get; }
    }
}