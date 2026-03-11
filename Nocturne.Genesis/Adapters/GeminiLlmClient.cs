using System.Net;
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

            const int maxRetries = 5;
            int delayMs = 500;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(jsonBody)
                };

                request.Content.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await Http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return ExtractGeminiContent(json);
                }

                if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    if (attempt == maxRetries)
                        throw new HttpRequestException("Rate limit exceeded after retries.");

                    await Task.Delay(delayMs);
                    delayMs *= 2;
                    continue;
                }

                response.EnsureSuccessStatusCode();
            }

            throw new HttpRequestException("Unexpected failure in GeminiLlmClient.");
        }

        private static string ExtractGeminiContent(string json)
        {
            using var doc = JsonDocument.Parse(json);

            return doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString()!;
        }
    }
}