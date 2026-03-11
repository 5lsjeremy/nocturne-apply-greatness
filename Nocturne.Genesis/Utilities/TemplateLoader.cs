using System.Text.Json;

namespace Nocturne.Genesis.Utilities;

public static class TemplateLoader
{
    public static T LoadTemplate<T>(string relativePath)
    {
        var fullPath = Path.Combine(AppContext.BaseDirectory, "SeedTemplates", relativePath);
        var json = File.ReadAllText(fullPath);
        return JsonSerializer.Deserialize<T>(json)!;
    }
}