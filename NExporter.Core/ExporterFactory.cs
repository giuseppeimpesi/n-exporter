using NExporter.Core.Exporters;
using NExporter.Core.Interfaces;
using NExporter.Models.Enumerations;

namespace NExporter.Core
{
    public sealed class ExporterFactory : IExporterFactory
    {
        private readonly IReadOnlyDictionary<ExportType, IExporter> _exporters;

        public ExporterFactory(IEnumerable<IExporter> exporters)
        {
            _exporters = exporters.GroupBy(x => x.ExportType).ToDictionary(g => g.Key, g => g.Single());
        }

        public IExporter Get(ExportType? type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type), "Exporter type is required");

            if (_exporters.TryGetValue(type.Value, out var exporter))
                return exporter;

            throw new NotSupportedException($"Exporter '{type}' not supported");
        }
    }
}
