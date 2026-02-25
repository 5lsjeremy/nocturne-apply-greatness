namespace Nocturne.Abstractions.Genesis
{
    public interface IGenesisFactory
    {
        IGenesisEngine Create(ISurfaceArtifact seed, IGenesisOptions? options = null);
    }
}