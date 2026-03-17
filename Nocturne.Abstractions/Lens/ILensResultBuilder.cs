namespace Nocturne.Abstractions.Lens
{
    public interface ILensResultBuilder
    {
        void AddDiagnosis(ILensDiagnosis diagnosis);
        void AddQuestion(ILensQuestion question);
        void AddPlannedUpdate(ILensPlannedUpdate update);

        ILensResult Build();
    }
}