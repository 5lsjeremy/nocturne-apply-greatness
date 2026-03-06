namespace Nocturne.Abstractions.Genesis.Concepts.Enums
{
    [Flags]
    public enum WorldFlags
    {
        None = 0,

        // Environmental
        Night = 1 << 0,
        Storm = 1 << 1,
        Winter = 1 << 2,
        HighAltitude = 1 << 3,

        // Narrative
        RouteCompromised = 1 << 4,
        StationBurned = 1 << 5,
        CourierCaptured = 1 << 6,

        // Systemic
        SparksLimited = 1 << 7,
        CollapseImminent = 1 << 8,
        RecoveryBoost = 1 << 9
    }
}