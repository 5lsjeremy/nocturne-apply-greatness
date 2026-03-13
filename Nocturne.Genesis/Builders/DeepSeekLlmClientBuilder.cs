using Nocturne.Genesis.Adapters;
using Nocturne.Genesis.Config;

namespace Nocturne.Genesis.Builders
{
    public sealed class DeepSeekLlmClientBuilder
    {
        private HttpClient? _http;
        private string? _endpoint;
        private string? _apiKey;

        private string? _scaffoldModel;
        private string? _refineModel;
        private string? _synthesisModel;
        private string? _premiumModel;

        public DeepSeekLlmClientBuilder UseHttpClient(HttpClient http)
        {
            _http = http;
            return this;
        }

        public DeepSeekLlmClientBuilder UseEndpoint(string endpoint)
        {
            _endpoint = endpoint;
            return this;
        }

        public DeepSeekLlmClientBuilder UseApiKey(string apiKey)
        {
            _apiKey = apiKey;
            return this;
        }

        public DeepSeekLlmClientBuilder UseScaffoldModel(string model)
        {
            _scaffoldModel = model;
            return this;
        }

        public DeepSeekLlmClientBuilder UseRefineModel(string model)
        {
            _refineModel = model;
            return this;
        }

        public DeepSeekLlmClientBuilder UseSynthesisModel(string model)
        {
            _synthesisModel = model;
            return this;
        }

        public DeepSeekLlmClientBuilder UsePremiumModel(string model)
        {
            _premiumModel = model;
            return this;
        }

        public DeepSeekLlmClient Build()
        {
            if (_http is null)
                throw new InvalidOperationException("HttpClient required");
            if (_endpoint is null)
                throw new InvalidOperationException("Endpoint required");
            if (_apiKey is null)
                throw new InvalidOperationException("API key required");

            if (_scaffoldModel is null ||
                _refineModel is null ||
                _synthesisModel is null ||
                _premiumModel is null)
            {
                throw new InvalidOperationException("All model fields must be provided.");
            }

            var config = new GenesisLlmConfig
            {
                Endpoint = _endpoint,
                ApiKey = _apiKey,
                ScaffoldModel = _scaffoldModel,
                RefineModel = _refineModel,
                SynthesisModel = _synthesisModel,
                PremiumModel = _premiumModel
            };

            return new DeepSeekLlmClient(_http, config);
        }
    }
}