using NExporter.Core.Interfaces;
using NExporter.Models.Enumerations;

namespace NExporter.Core
{
    public sealed class ExportService : IExportService
    {
        private readonly IExporterFactory _factory;

        public ExportService(IExporterFactory factory)
        {
            _factory = factory;
        }

        public byte[] Export<T>(ExportType format, IEnumerable<T> data)
        {
            var exporter = _factory.Get(format);

            return exporter.Export(data);
        }
    }
}
