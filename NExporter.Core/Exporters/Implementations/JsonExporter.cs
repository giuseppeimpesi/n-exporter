using NExporter.Models.Enumerations;

namespace NExporter.Core.Exporters.Implementations
{
    public sealed class JsonExporter : IExporter
    {
        public ExportType ExportType => ExportType.Json;

        public byte[] Export<T>(IEnumerable<T> data)
        {
            throw new NotImplementedException("JSON export is not implemented yet.");
        }
    }
}
