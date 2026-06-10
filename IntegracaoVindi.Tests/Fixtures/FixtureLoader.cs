using System.IO;
using System.Reflection;

namespace IntegracaoVindi.Tests.Fixtures
{
    internal static class FixtureLoader
    {
        public static string Load(string relativePath)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Converte o path em nome do recurso embutido
            var resourceName = $"{assembly.GetName().Name}.Fixtures.{relativePath
                .Replace("/", ".")
                .Replace("\\", ".")}";

            using var stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new FileNotFoundException(
                    $"Fixture não encontrada: {resourceName}");

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
