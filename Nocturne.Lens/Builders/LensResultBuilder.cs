//v.01 updated 26.03.18

using Nocturne.Abstractions.Lens;
using Nocturne.Lens.Abstractions.Models;

namespace Nocturne.Lens.Builders
{
    internal sealed class LensResultBuilder : ILensResultBuilder
    {
        private readonly List<ILensDiagnosis> _diagnoses = new();
        private readonly List<ILensQuestion> _questions = new();
        private readonly List<ILensPlannedUpdate> _updates = new();

        public void AddDiagnosis(ILensDiagnosis diagnosis)
        {
            if (diagnosis != null)
                _diagnoses.Add(diagnosis);
        }

        public void AddQuestion(ILensQuestion question)
        {
            if (question != null)
                _questions.Add(question);
        }

        public void AddPlannedUpdate(ILensPlannedUpdate update)
        {
            if (update != null)
                _updates.Add(update);
        }

        public ILensResult Build()
        {
            return new LensResult
            {
                Diagnoses = _diagnoses,
                Questions = _questions,
                PlannedUpdates = _updates
            };
        }
    }
}