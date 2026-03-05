using Nocturne.Genesis.Adapters;

namespace Nocturne.Genesis.Builders
{
    public sealed class GeminiLlmClientBuilder
    {
        private HttpClient? _http;
        private string? _endpoint;
        private string? _apiKey;
        private string? _model;

        public GeminiLlmClientBuilder UseHttpClient(HttpClient http)
        {
            _http = http;
            return this;
        }

        public GeminiLlmClientBuilder UseEndpoint(string endpoint)
        {
            _endpoint = endpoint;
            return this;
        }

        public GeminiLlmClientBuilder UseApiKey(string apiKey)
        {
            _apiKey = apiKey;
            return this;
        }

        public GeminiLlmClientBuilder UseModel(string model)
        {
            _model = model;
            return this;
        }

        public GeminiLlmClient Build()
        {
            return new GeminiLlmClient(
                _http ?? throw new InvalidOperationException("HttpClient required"),
                _endpoint ?? throw new InvalidOperationException("Endpoint required"),
                _apiKey ?? throw new InvalidOperationException("API key required"),
                _model ?? throw new InvalidOperationException("Model required")
            );
        }
    }
}