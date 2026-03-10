namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IWorldPackageBuilder
    {
        void WriteInitialPackage(IGenesisSession session, ISurfaceWorldContext context);
    }

}