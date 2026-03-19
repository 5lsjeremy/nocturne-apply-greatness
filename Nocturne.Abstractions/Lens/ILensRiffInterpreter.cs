//v.01 updated 26.03.18
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Lens;

namespace Nocturne.Abstractions.Lens
{
    public interface ILensRiffInterpreter
    {
        /// <summary>
        /// Interpret a riffed Genesis card into one or more Lens artifacts.
        /// </summary>
        IReadOnlyList<object> Interpret(ICard riffedCard, ILensContext context);
        // Returned objects may be:
        // - ILensDiagnosis
        // - ILensPlannedUpdate
        // - ILensQuestion
    }
}