using NExporter.Models.Enumerations;

namespace NExporter.Core.Exporters
{
    public interface IExporter
    {
        ExportType ExportType { get; }
        byte[] Export<T>(IEnumerable<T> data);
    }
}
