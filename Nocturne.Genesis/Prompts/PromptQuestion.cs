using System.Collections.Generic;

namespace Nocturne.Genesis.Prompts
{
    internal sealed class PromptQuestion
    {
        public string Id { get; set; } = string.Empty;
        public string OfflinePrompt { get; set; } = string.Empty;
        public string LlmPromptTemplate { get; set; } = string.Empty;
        public List<string> Axes { get; set; } = new();
        public int Order { get; set; }
    }
}