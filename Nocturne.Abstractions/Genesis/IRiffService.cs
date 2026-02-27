namespace Nocturne.Abstractions.Genesis
{
    public interface IRiffService
    {
        ICard Riff(ICard card, string contributor, string prompt);
    }
}