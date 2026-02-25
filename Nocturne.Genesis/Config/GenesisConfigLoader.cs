using System.Text.Json;

namespace Nocturne.Genesis.Config
{
    internal static class GenesisConfigLoader
    {
        public static GenesisConfig Load(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<GenesisConfig>(json) ?? new GenesisConfig();
        }
    }
}