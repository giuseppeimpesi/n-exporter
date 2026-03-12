using NExporter.Models.Enumerations;

namespace NExporter.Core.Interfaces
{
    public interface IExportService
    {
        byte[] Export<T>(ExportType type, IEnumerable<T> data);
    }
}
