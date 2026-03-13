using System.Text.Json;
using System.Text.RegularExpressions;
using Nocturne.Abstractions.WorldPackageSchema.CardDTO;
using Nocturne.Abstractions.WorldPackageSchema.ConceptDTO;
using Nocturne.Abstractions.WorldPackageSchema.DomainDTO;
using Nocturne.Abstractions.WorldPackageSchema.PresentationDTO;
using Nocturne.Abstractions.WorldPackageSchema.StarterDeckDTO;
using Nocturne.Abstractions.WorldPackageSchema.UnifiedWorldPackageDTO;

namespace Nocturne.Genesis.Assemblers;

public class UnifiedWorldPackageAssembler
{
    private readonly string _rootPath;

    public UnifiedWorldPackageAssembler(string rootPath)
    {
        _rootPath = rootPath;
    }

    public void Assemble(string unifiedJson)
    {
        var dto = JsonSerializer.Deserialize<UnifiedWorldPackageDto>(unifiedJson)
                  ?? throw new Exception("Failed to deserialize unified world package JSON.");

        var index = new WorldPackageIndexDto
        {
            PackageId = dto.Concept?.Id ?? Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Domains = [],
            Cards = [],
            StarterDeckId = null
        };

        WriteConcept(dto.Concept, index);
        WritePresentation(dto.Presentation, index);

        foreach (var domain in dto.Domains)
            WriteDomain(domain, index);

        // Cards are always empty now — skip writing card files
        // StarterDeck is always null — skip writing deck files

        WriteIndex(index);
    }

    // ------------------------------
    // Artifact Writers
    // ------------------------------

    private void WriteDomain(DomainDefinition domain, WorldPackageIndexDto index)
    {
        var slug = Slugify(domain.DomainName);
        var idLast5 = Last5(domain.Id);
        var date = DateStamp();
        var version = "v1.0";

        var filename = $"dm_{slug}_{idLast5}_{date}_{version}.json";
        var path = Path.Combine(_rootPath, "Domains", filename);

        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonSerializer.Serialize(domain, JsonOptions()));

        index.Domains.Add(domain.Id);
    }

    private void WriteConcept(ConceptArtifactsDTO concept, WorldPackageIndexDto index)
    {
        var slug = Slugify(concept.Core.WorldName);
        var idLast5 = Last5(concept.Id);
        var date = DateStamp();
        var version = "v1.0";

        var filename = $"cn_{slug}_{idLast5}_{date}_{version}.json";
        var path = Path.Combine(_rootPath, "Concept", filename);

        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonSerializer.Serialize(concept, JsonOptions()));

        index.ConceptId = concept.Id;
    }

    private void WritePresentation(PresentationDefinition pres, WorldPackageIndexDto index)
    {
        var slug = Slugify(pres.Title);
        var idLast5 = RandomSuffix();
        var date = DateStamp();
        var version = "v1.0";

        var filename = $"pr_{slug}_{idLast5}_{date}_{version}.json";
        var path = Path.Combine(_rootPath, "Presentation", filename);

        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonSerializer.Serialize(pres, JsonOptions()));

        index.PresentationId = pres.Id;
    }

    private void WriteIndex(WorldPackageIndexDto index)
    {
        var path = Path.Combine(_rootPath, "worldPackageIndex.json");
        File.WriteAllText(path, JsonSerializer.Serialize(index, JsonOptions()));
    }

    // ------------------------------
    // Helpers
    // ------------------------------

    private static string Slugify(string input)
    {
        input = input.ToLowerInvariant();
        input = Regex.Replace(input, @"[^a-z0-9]+", "-");
        return input.Trim('-');
    }

    private static string Last5(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return RandomSuffix();
        return id.Length <= 5 ? id : id[^5..];
    }

    private static string RandomSuffix()
    {
        return Guid.NewGuid().ToString("N")[^5..];
    }

    private static string DateStamp()
    {
        var now = DateTime.UtcNow;
        return $"{now:ddyyMM}";
    }

    private static JsonSerializerOptions JsonOptions()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}