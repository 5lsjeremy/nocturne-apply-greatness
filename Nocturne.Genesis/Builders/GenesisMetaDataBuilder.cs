using Nocturne.Genesis.Engine;

namespace Nocturne.Genesis.Builders
{
    internal sealed class GenesisMetadataBuilder
    {
        public Dictionary<string, object> Build(GenesisContext context)
        {
            return new Dictionary<string, object>
            {
                { "SeedId", context.Seed.Id },
                { "SeedName", context.Seed.Name },
                { "GeneratedAt", DateTime.UtcNow },
                { "AnswerCount", context.Answers.Count },
                { "CardCount", context.Cards.Count }
            };
        }
    }
}