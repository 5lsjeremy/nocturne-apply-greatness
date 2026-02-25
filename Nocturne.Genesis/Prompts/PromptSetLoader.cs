using System.IO;
using System.Text.Json;

namespace Nocturne.Genesis.Prompts
{
    internal static class PromptSetLoader
    {
        public static PromptSet Load(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<PromptSet>(json) ?? new PromptSet();
        }
    }
}