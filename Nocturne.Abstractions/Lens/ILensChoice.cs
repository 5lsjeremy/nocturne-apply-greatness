namespace Nocturne.Abstractions.Lens
{
    public interface ILensChoice
    {
        string Id { get; }
        string Label { get; }
        string? Details { get; }
    }
}