using System.Text.Json;

namespace Nocturne.Genesis.Adapters
{
    public sealed class CopilotLlmClient : GenesisLlmClientBase
    {
        public CopilotLlmClient(
            HttpClient http,
            string endpoint,
            string apiKey,
            string model)
            : base(http, endpoint, apiKey, model)
        {
        }

        public override async Task<string> CompleteAsync(string prompt)
        {
            var body = new
            {
                model = Model,
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, Endpoint)
            {
                Content = new StringContent(JsonSerializer.Serialize(body))
            };

            request.Headers.Add("api-key", ApiKey);
            request.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await Http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return ExtractContent(json);
        }
    }
}