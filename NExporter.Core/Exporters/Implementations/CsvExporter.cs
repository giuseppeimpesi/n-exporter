using NExporter.Models.Enumerations;

namespace NExporter.Core.Exporters.Implementations
{
    public sealed class CsvExporter : IExporter
    {
        public ExportType ExportType => ExportType.Csv;

        public byte[] Export<T>(IEnumerable<T> data)
        {
            throw new NotImplementedException("Csv export is not implemented yet.");
        }
    }
}
