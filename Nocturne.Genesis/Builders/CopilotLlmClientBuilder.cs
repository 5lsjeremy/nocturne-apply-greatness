using Nocturne.Genesis.Adapters;

namespace Nocturne.Genesis.Builders
{
    public sealed class CopilotLlmClientBuilder
    {
        private HttpClient? _http;
        private string? _endpoint;
        private string? _apiKey;
        private string? _model;

        public CopilotLlmClientBuilder UseHttpClient(HttpClient http)
        {
            _http = http;
            return this;
        }

        public CopilotLlmClientBuilder UseEndpoint(string endpoint)
        {
            _endpoint = endpoint;
            return this;
        }

        public CopilotLlmClientBuilder UseApiKey(string apiKey)
        {
            _apiKey = apiKey;
            return this;
        }

        public CopilotLlmClientBuilder UseModel(string model)
        {
            _model = model;
            return this;
        }

        public CopilotLlmClient Build()
        {
            return new CopilotLlmClient(
                _http ?? throw new InvalidOperationException("HttpClient required"),
                _endpoint ?? throw new InvalidOperationException("Endpoint required"),
                _apiKey ?? throw new InvalidOperationException("API key required"),
                _model ?? throw new InvalidOperationException("Model required")
            );
        }
    }
}