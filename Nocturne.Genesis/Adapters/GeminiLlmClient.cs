using System.Net.Http;
using System.Text.Json;

namespace Nocturne.Genesis.Adapters
{
    public sealed class GeminiLlmClient : GenesisLlmClientBase
    {
        public GeminiLlmClient(
            HttpClient http,
            string endpoint,
            string apiKey,
            string model)
            : base(http, endpoint, apiKey, model)
        {
        }

        public override async Task<string> CompleteAsync(string prompt)
        {
            // Gemini endpoint format:
            // {Endpoint}/v1beta/models/{Model}:generateContent?key={ApiKey}
            var url = $"{Endpoint}/v1beta/models/{Model}:generateContent?key={ApiKey}";

            var body = new
            {
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };


            var jsonBody = JsonSerializer.Serialize(body);

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(jsonBody)
            };

            request.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await Http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return ExtractGeminiContent(json);
        }

        private static string ExtractGeminiContent(string json)
        {
            using var doc = JsonDocument.Parse(json);

            // Gemini response shape:
            // candidates[0].content.parts[0].text
            return doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString()!;
        }
    }
}