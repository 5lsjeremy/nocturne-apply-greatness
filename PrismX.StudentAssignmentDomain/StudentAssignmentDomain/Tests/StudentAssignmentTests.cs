using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PrismX.Shared.Types.Clusters;
using PrismX.Shared.Types.Contracts.Base.Context;
using PrismX.Shared.Types.Contracts.Context;
using PrismX.Shared.Types.Contracts.Engines;
using PrismX.Shared.Types.Contracts.States;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Tests
{
    [TestFixture]
    public class StudentAssignmentEndToEndTests
    {
        private ServiceProvider _provider = default!;
        private IEngineBase _engine = default!;

        [SetUp]
        public void Setup()
        {
            _provider = StudentAssignmentTestBootstrap.Build();
            _engine = _provider.GetRequiredService<IEngineBase>();
        }

        [Test]
        public async Task EndToEnd_PipelineExecutes_TwoActions()
        {
            var actionDefinition = _provider.GetRequiredService<IActionDefinition>();
            var time = _provider.GetRequiredService<ITimeState>();
            var random = _provider.GetRequiredService<IRandomState>();
            var sim = _provider.GetRequiredService<ISimulationState>();

            // ---------------------------------------------------------
            // FIRST ACTION
            // ---------------------------------------------------------
            var input1 = new StudentAnalyzeInput
            {
                AssignmentText = "Explain the causes of the Civil War.",
                StudentResponse = "Some response",
                UnitSlug = "history.civilwar.causes"
            };

            var result1 = await _engine.HandleAsync<StudentAnalyzeAction>(
                actionDefinition, time, random, sim, input1);

            var ctx1 = (IPrismContext)result1.Context;
            var cluster1 = sim.Clusters
                .First(c => c.Provenance.Source != "ClusteringEngine");



            Console.WriteLine("\n==============================");
            Console.WriteLine("======= FIRST ACTION =========");
            Console.WriteLine("==============================");
            DumpContext(ctx1);
            DumpCluster(cluster1);
            DumpContextMetadata(ctx1);
            DumpClusterProvenance(cluster1);

            Assert.That(ctx1.CurrentMagnitude, Is.GreaterThan(0f));

            // ---------------------------------------------------------
            // SECOND ACTION
            // ---------------------------------------------------------
            var input2 = new StudentAnalyzeInput
            {
                AssignmentText = "Describe how economic differences between the North and South contributed to the Civil War.",
                StudentResponse = "The North industrialized while the South relied on slavery-based agriculture.",
                UnitSlug = "history.civilwar.causes"
            };

            var result2 = await _engine.HandleAsync<StudentAnalyzeAction>(
                actionDefinition, time, random, sim, input2);

            var ctx2 = (IPrismContext)result2.Context;
            var cluster2 = sim.Clusters
                .Last(c => c.Provenance.Source != "ClusteringEngine");


            Console.WriteLine("\n==============================");
            Console.WriteLine("======= SECOND ACTION ========");
            Console.WriteLine("==============================");
            DumpContext(ctx2);
            DumpCluster(cluster2);
            DumpContextMetadata(ctx2);
            DumpClusterProvenance(cluster2);

            // ---------------------------------------------------------
            // DIFF + MASTERY CURVE
            // ---------------------------------------------------------
            Console.WriteLine("\n==============================");
            Console.WriteLine("======= MASTERY CURVE ========");
            Console.WriteLine("==============================");

            float m1 = (float)cluster1.Metadata["masteryScore"];
            float m2 = (float)cluster2.Metadata["masteryScore"];

            Console.WriteLine($"Mastery 1 → 2: {m1} → {m2}");
            Console.WriteLine($"Δ Mastery: {m2 - m1}");

            Assert.That(ctx2.CurrentMagnitude, Is.GreaterThan(ctx1.CurrentMagnitude));
        }

        // ---------------------------------------------------------
        // HELPERS
        // ---------------------------------------------------------

        private static void DumpContext(IPrismContext ctx)
        {
            Console.WriteLine("=== VECTOR PHYSICS ===");
            Console.WriteLine($"Direction:  {ctx.CurrentDirection}");
            Console.WriteLine($"Magnitude:  {ctx.CurrentMagnitude}");
            Console.WriteLine($"Confidence: {ctx.CurrentConfidence}");
            Console.WriteLine($"Stability:  {ctx.CurrentStability}");
            Console.WriteLine($"Variance:   {ctx.CurrentVariance}");
        }

        private static void DumpCluster(ClusterBase cluster)
        {
            Console.WriteLine("\n=== CLUSTER PHYSICS ===");
            Console.WriteLine($"Centroid:   {cluster.Centroid}");
            Console.WriteLine($"Confidence: {cluster.Confidence}");
            Console.WriteLine($"Stability:  {cluster.Stability}");
            Console.WriteLine($"Variance:   {cluster.Variance}");
            Console.WriteLine($"Polarity:   {cluster.Polarity}");

            Console.WriteLine("\n=== CLUSTER TAGS ===");
            Console.WriteLine(string.Join(", ", cluster.Tags));

            Console.WriteLine("\n=== CLUSTER METADATA (PRISM + DOMAIN) ===");
            foreach (var kv in cluster.Metadata)
                Console.WriteLine($"  {kv.Key}: {kv.Value}");
        }

        private static void DumpContextMetadata(IPrismContext ctx)
        {
            Console.WriteLine("\n=== PRISM CONTEXT METADATA ===");
            foreach (var kv in ctx.ClusterMetadata)
                Console.WriteLine($"  {kv.Key}: {kv.Value}");
        }

        private static void DumpClusterProvenance(ClusterBase cluster)
        {
            Console.WriteLine("\n=== CLUSTER PROVENANCE ===");
            Console.WriteLine($"  Source:    {cluster.Provenance.Source}");
            Console.WriteLine($"  Timestamp: {cluster.Provenance.Timestamp}");
            Console.WriteLine($"  Action:    {cluster.Provenance.ActionId}");
        }

        [TearDown]
        public void TearDown()
        {
            _provider?.Dispose();
        }
    }
}