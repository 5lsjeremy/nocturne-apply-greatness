namespace Nocturne.Genesis.Prompts
{
    internal static class PromptMerger
    {
        public static string ApplyLocalization(string basePrompt, PromptLocalization loc)
        {
            if (loc.Adjectives == null || loc.Adjectives.Count == 0)
                return basePrompt;

            var result = basePrompt;

            foreach (var kvp in loc.Adjectives)
            {
                var token = "{" + kvp.Key + "}";
                if (result.Contains(token))
                {
                    var adjectives = string.Join(", ", kvp.Value);
                    result = result.Replace(token, adjectives);
                }
            }

            return result;
        }
    }
}