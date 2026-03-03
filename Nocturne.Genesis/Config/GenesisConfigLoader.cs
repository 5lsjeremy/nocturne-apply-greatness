using System.Text.Json;

namespace Nocturne.Genesis.Config
{
    internal static class GenesisConfigLoader
    {
        public static GenesisConfig Load(string path)
        {
            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<GenesisConfig>(json, options) 
                   ?? new GenesisConfig();

        }
    }
}