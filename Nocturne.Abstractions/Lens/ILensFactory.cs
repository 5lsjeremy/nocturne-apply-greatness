namespace Nocturne.Abstractions.Lens
{
    public interface ILensFactory
    {
        ILensService Create();
    }
}