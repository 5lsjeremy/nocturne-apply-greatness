using Nocturne.Abstractions.Genesis;
using Nocturne.Genesis.Engine;

namespace Nocturne.Genesis.Services
{
    internal sealed class GenesisInferenceService : IGenesisInferenceService
    {
        public void InferWorldShape(IGenesisContext context)
        {
            var concrete = (GenesisContext)context;

            // TODO: inference logic populating concrete.Cards with GenesisCard instances
            // and setting their axes (Intent, Scope, Energy, etc.).
        }
    }
}