using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Abstractions.Genesis
{
    public interface IConceptService
    {
        Task<IConcept> EvaluateAsync(string worldConcept);
    }
}