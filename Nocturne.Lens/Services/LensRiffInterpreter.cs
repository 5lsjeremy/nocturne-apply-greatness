//v.01 updated 26.03.18
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Lens;
using Nocturne.Lens.Abstractions.Models;

namespace Nocturne.Lens.Services
{
    internal sealed class LensRiffInterpreter : ILensRiffInterpreter
    {
        public IReadOnlyList<object> Interpret(ICard riffedCard, ILensContext context)
        {
            context.Logger.Info($"Interpreting riffed card: {riffedCard.Name}");

            var results = new List<object>();

            // ------------------------------------------------------------
            // TODO: 1. Interpret as Diagnosis
            // Example heuristic:
            // - If card.Tags contains "problem" or "issue"
            // - If card.Properties["severity"] exists
            // ------------------------------------------------------------

            // ------------------------------------------------------------
            // TODO: 2. Interpret as Planned Update
            // Example heuristic:
            // - If card.Tags contains "update" or "change"
            // - If card.Properties["target"] exists
            // ------------------------------------------------------------

            // ------------------------------------------------------------
            // TODO: 3. Interpret as Follow-up Question
            // Example heuristic:
            // - If card.Tags contains "question"
            // - If card.Properties["prompt"] exists
            // ------------------------------------------------------------

            // For now, return empty until heuristics are implemented
            return results;
        }
    }
}