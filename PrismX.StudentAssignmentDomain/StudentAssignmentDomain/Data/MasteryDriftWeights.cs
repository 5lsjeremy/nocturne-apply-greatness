namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Data;

public static class MasteryDriftWeights
{
    public const float BasePositive = +0.5f;
    public const float BaseNegative = -0.5f;

    public static readonly Dictionary<string, float> Cognitive = new()
    {
        ["reasoning"]      = +0.3f,
        ["explanation"]    = +0.2f,
        ["recall"]         = +0.1f,
        ["synthesis"]      = +0.4f
    };

    public static readonly Dictionary<string, float> Affective = new()
    {
        ["engagement"]     = +0.2f,
        ["confidence"]     = +0.2f,
        ["frustration"]    = -0.3f
    };

    public static readonly Dictionary<string, float> Difficulty = new()
    {
        ["easy"]           = +0.2f,
        ["medium"]         =  0.0f,
        ["hard"]           = -0.2f
    };

    public const float MisconceptionPenalty = -0.3f;
}