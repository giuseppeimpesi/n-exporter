using NExporter.Core.Exporters;
using NExporter.Models.Enumerations;

namespace NExporter.Core.Interfaces
{
    public interface IExporterFactory
    {
        IExporter Get(ExportType? type);
    }
}
