using Microsoft.Extensions.DependencyInjection;
using PrismX.Crucible.Extensions;
using PrismX.Crucible.Types.Registries;
using PrismX.Shared.Types.Actions.Implementations;
using PrismX.Shared.Types.Builders;
using PrismX.Shared.Types.Contracts.Context;
using PrismX.Shared.Types.Contracts.Factory;
using PrismX.Shared.Types.Contracts.Initializer;
using PrismX.Shared.Types.Factories.Results;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Engines;
using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Extensions
{
    public static class StudentAssignmentServiceExtensions
    {
        public static IServiceCollection AddStudentAssignment(this IServiceCollection services)
        {
            return services.AddDomain<StudentAnalyzeAction>(domain =>
            {
                //
                // 🔹 Router + Action Definition
                //
                domain.AddSingleton<StudentAssignmentRouter>();
                domain.AddSingleton<IActionRouter>(sp =>
                    sp.GetRequiredService<StudentAssignmentRouter>());

                domain.AddSingleton<StudentAnalyzeActionDefinition>();
                domain.AddSingleton<IActionDefinition>(sp =>
                    sp.GetRequiredService<StudentAnalyzeActionDefinition>());

                //
                // 🔹 Action Implementation (no‑op)
                //
                domain.AddSingleton<IActionImplementation<StudentAnalyzeAction>,
                    StudentAnalyzeActionImplementation>();

                //
                // 🔹 Vector Builder + Result Factory
                //
                domain.AddSingleton<IResolvedVectorBuilder<StudentAnalyzeAction>,
                    StudentAnalyzeVectorBuilder>();

                domain.AddSingleton<IResultVectorFactory<StudentAnalyzeAction>,
                    ResultVectorFactory<StudentAnalyzeAction>>();

                //
                // 🔹 Mastery Engines (⭐ REQUIRED ⭐)
                //
                domain.AddSingleton<IMasteryDriftEngine, DefaultMasteryDriftEngine>();
                domain.AddSingleton<IDifficultyDriftScalingEngine, DefaultDifficultyDriftScalingEngine>();
                domain.AddSingleton<IMasteryProgressionEngine, DefaultMasteryProgressionEngine>();
                domain.AddSingleton<IMasteryThresholdEngine, DefaultMasteryThresholdEngine>();

                //
                // 🔹 Registry + Initializer
                //
                domain.AddSingleton<ActionRegistry>();
                domain.AddSingleton<IDomainInitializer, StudentAssignmentInitializer>();
            });
        }
    }
}