using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Factories;
using Nocturne.TestHarness;

namespace RunnerHarness
{
    class Program
    {
        static async Task Main()
        {
            // The ONLY place in your entire solution where concrete Genesis types appear.
            IGenesisFactory factory = new GenesisFactory();

            // Pass the factory into the interface-only harness.
            await Harness.Run(factory);
        }
    }
}