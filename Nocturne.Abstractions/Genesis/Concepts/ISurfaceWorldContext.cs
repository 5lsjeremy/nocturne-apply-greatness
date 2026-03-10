namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface ISurfaceWorldContext
    {
        string RootPath { get; }
        string WorldName { get; }
        string Version { get; }
    }
}