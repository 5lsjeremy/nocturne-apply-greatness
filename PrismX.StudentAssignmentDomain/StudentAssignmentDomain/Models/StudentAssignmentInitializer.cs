using PrismX.Crucible.Types.Registries;
using PrismX.Shared.Types.Contracts.Initializer;
using PrismX.Shared.Types.Contracts.Overlays;
using PrismX.Shared.Types.Contracts.Registries;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models
{
    public sealed class StudentAssignmentInitializer : IDomainInitializer
    {
        private readonly StudentAssignmentRouter _router;
        private readonly StudentAnalyzeActionDefinition _definition;
        private readonly ActionRegistry _actionRegistry;
        private readonly IOverlayRegistry _overlayRegistry;
        private readonly IVectorOverlay _vectorOverlay;

        public StudentAssignmentInitializer(
            StudentAssignmentRouter router,
            StudentAnalyzeActionDefinition definition,
            ActionRegistry actionRegistry,
            IOverlayRegistry overlayRegistry,
            IVectorOverlay vectorOverlay)
        {
            _router = router;
            _definition = definition;
            _actionRegistry = actionRegistry;
            _overlayRegistry = overlayRegistry;
            _vectorOverlay = vectorOverlay;
        }

        public void Initialize(IConstellationRegistry registry)
        {
            registry.RegisterActionRouter(_router);
            _actionRegistry.Register(_definition);
            _overlayRegistry.Register(_vectorOverlay);
        }
    }
}