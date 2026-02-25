using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Engine
{
    internal sealed class GenesisEngine : IGenesisEngine
    {
        private readonly ISurfaceArtifact _seed;
        private readonly IGenesisBuilder _builder;
        private readonly IGenesisInferenceService _inference;
        private readonly IGenesisPromptService _prompts;

        public GenesisEngine(
            ISurfaceArtifact seed,
            IGenesisBuilder builder,
            IGenesisInferenceService inference,
            IGenesisPromptService prompts)
        {
            _seed = seed;
            _builder = builder;
            _inference = inference;
            _prompts = prompts;
        }

        public IStarterDeck Generate()
        {
            var context = new GenesisContext(_seed);

            _prompts.RunMvpLoop(context);
            _inference.InferWorldShape(context);

            return _builder.BuildStarterDeck(context);
        }
    }
}