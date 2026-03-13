using System.Net.Http;
using System.Text.Json;
using Nocturne.Abstractions.Genesis;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Adapters
{
    public abstract class GenesisLlmClientBase : IGenesisLlmClient
    {
        protected readonly HttpClient Http;
        protected readonly string Endpoint;
        protected readonly string ApiKey;
        protected readonly string Model;

        protected GenesisLlmClientBase(
            HttpClient http,
            string endpoint,
            string apiKey,
            string model)
        {
            Http = http;
            Endpoint = endpoint;
            ApiKey = apiKey;
            Model = model;
        }

        public abstract Task<string> CompleteAsync(string prompt, LlmTaskType task);
        
        protected static string ExtractContent(string json)
        {
            using var doc = JsonDocument.Parse(json);

            return doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString()!;
        }
    }
}