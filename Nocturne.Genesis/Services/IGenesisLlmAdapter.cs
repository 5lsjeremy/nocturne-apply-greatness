namespace Nocturne.Genesis.Services
{
    internal interface IGenesisLlmAdapter
    {
        string Generate(string prompt);
    }
}