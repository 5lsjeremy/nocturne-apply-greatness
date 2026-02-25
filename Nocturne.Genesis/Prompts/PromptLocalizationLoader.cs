using System.Text.Json;

namespace Nocturne.Genesis.Prompts
{
    internal static class PromptLocalizationLoader
    {
        public static PromptLocalization Load(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<PromptLocalization>(json) ?? new PromptLocalization();
        }
    }
}