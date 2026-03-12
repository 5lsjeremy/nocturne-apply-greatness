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
    var url = $"{Endpoint}/v1/models/{Model}:generateContent?key={ApiKey}";

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
    var rng = new Random();

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

            // Respect Retry-After header if present
            if (response.Headers.TryGetValues("Retry-After", out var values) &&
                int.TryParse(values.FirstOrDefault(), out var retryAfterSeconds))
            {
                await Task.Delay(TimeSpan.FromSeconds(retryAfterSeconds));
                continue;
            }

            // Exponential backoff with full jitter
            var baseDelaySeconds = Math.Pow(2, attempt); // 2, 4, 8, 16, 32
            var jitter = rng.NextDouble();               // 0.0–1.0
            var delay = TimeSpan.FromSeconds(baseDelaySeconds * jitter);

            await Task.Delay(delay);
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