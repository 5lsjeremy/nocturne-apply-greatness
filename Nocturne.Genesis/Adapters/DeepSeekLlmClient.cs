using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Nocturne.Abstractions.Genesis.Concepts.Enums;

namespace Nocturne.Genesis.Adapters
{
    public sealed class DeepSeekLlmClient : GenesisLlmClientBase
    {
        public DeepSeekLlmClient(HttpClient http, string endpoint, string apiKey, string model)
            : base(http, endpoint, apiKey, model)
        {
        }

        private string ResolveModel(LlmTaskType task)
        {
            // DeepSeek-chat is strong enough for all stages.
            // If you want to differentiate later, you can map task → model here.
            return Model; 
        }

        public override async Task<string> CompleteAsync(string prompt, LlmTaskType task)
        {
            var model = ResolveModel(task);

            var url = $"{Endpoint}/v1/chat/completions";

            var body = new
            {
                model = model,
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var jsonBody = JsonSerializer.Serialize(body);

            const int maxRetries = 5;
            var rng = new Random();

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await Http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return ExtractDeepSeekContent(json);
                }

                if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    if (attempt == maxRetries)
                        throw new HttpRequestException("Rate limit exceeded after retries.");

                    if (response.Headers.TryGetValues("Retry-After", out var values) &&
                        int.TryParse(values.FirstOrDefault(), out var retryAfterSeconds))
                    {
                        await Task.Delay(TimeSpan.FromSeconds(retryAfterSeconds));
                        continue;
                    }

                    var baseDelaySeconds = Math.Pow(2, attempt);
                    var jitter = rng.NextDouble();
                    var delay = TimeSpan.FromSeconds(baseDelaySeconds * jitter);

                    await Task.Delay(delay);
                    continue;
                }

                var bodyText = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"DeepSeek error: {bodyText}");
            }

            throw new HttpRequestException("Unexpected failure in DeepSeekLlmClient.");
        }

        private static string ExtractDeepSeekContent(string json)
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