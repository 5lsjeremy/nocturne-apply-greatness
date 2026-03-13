using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Factories;
using Nocturne.TestHarness;

namespace RunnerHarness
{
    class Program
    {
        static async Task Main()
        {
            // Load concept JSON from the concepts folder
            var concept = ConceptLoader.Load("concepts/concept_cryo_nation.json");

            // Create the surface artifact using loaded data
            var seed = new TestSurfaceArtifact(
                concept.Name ?? "Untitled Concept",
                concept.WorldConcept ?? "No concept provided."
            );

            // The ONLY place in your entire solution where concrete Genesis types appear.
            IGenesisFactory factory = new GenesisFactory();

            // Pass the factory and the artifact into the interface-only harness.
            await Harness.Run(factory, seed);
        }
    }
}