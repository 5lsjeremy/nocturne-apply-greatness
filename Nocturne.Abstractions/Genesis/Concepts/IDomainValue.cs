namespace Nocturne.Abstractions.Genesis.Concepts
{
    public interface IDomainValue
    {
        float Current { get; set; }
        float Gravity { get; set; }
        float Threshold { get; set; }
    }
}