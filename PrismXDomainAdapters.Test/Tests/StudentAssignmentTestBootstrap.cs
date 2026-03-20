using Microsoft.Extensions.DependencyInjection;
using PrismX.Constellation.Init;
using PrismX.Crucible.Extensions;
using PrismX.Crucible.Prism;
using PrismX.Crucible.Types.Modules.Overlays;
using PrismX.Shared.Types.Contracts.Overlays;
using PrismX.Shared.Types.Contracts.States;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Extensions;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

namespace PrismXDomainAdapters.Test.Tests;

public static class StudentAssignmentTestBootstrap
{
    public static ServiceProvider Build()
    {
        var services = new ServiceCollection();

        // Required overlay for vector processing
        services.AddSingleton<IVectorOverlay, VectorOverlay>();

        // Persistent PRISM memory (required for reinforcement)
        services.AddSingleton<SimulationState>();
        services.AddSingleton<ISimulationState>(sp => sp.GetRequiredService<SimulationState>());

        // PRISM core (same as TravelChaos)
        services.AddCrucible();
        services.AddPrism();
        services.AddConstellation();

        // Your domain (instead of AddTravelChaos)
        services.AddStudentAssignment();

        var provider = services.BuildServiceProvider();

        // Required for constellation-based domains
        provider.GetRequiredService<IConstellationInitializer>().Initialize();

        return provider;
    }
}