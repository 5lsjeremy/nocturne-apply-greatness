namespace Nocturne.Abstractions.Lens
{
    public interface ILensResult
    {
        IReadOnlyList<ILensDiagnosis> Diagnoses { get; }
        IReadOnlyList<ILensQuestion> Questions { get; }
        IReadOnlyList<ILensPlannedUpdate> PlannedUpdates { get; }
    }
}