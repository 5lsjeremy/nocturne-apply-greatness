using System.IO;
using System.Text.Json;
using RunnerHarness;

public static class ConceptLoader
{
    public static ConceptFile Load(string path)
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<ConceptFile>(json)
               ?? new ConceptFile();
    }
}