using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Nocturne.Abstractions.Genesis.Lineage;

namespace Nocturne.Genesis.Services.Lineage
{
    public class FingerprintService : IFingerprintService
    {
        public string ComputeFingerprint(object artifact)
        {
            var json = JsonSerializer.Serialize(artifact);
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(json));
            return Convert.ToHexString(bytes);
        }
    }
}