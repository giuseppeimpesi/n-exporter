using NExporter.Models.Attributes;
using System.Reflection;

namespace NExporter.Core.Exporters
{
    public class BaseExporter
    {
        public BaseExporter() { }

        public bool IsExportable<T>()
        {
            return typeof(T).IsDefined(typeof(ExportableAttribute), inherit: true);
        }

        public ExportableAttribute GetExportableAttribute<T>()
        {
            return (ExportableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(ExportableAttribute), inherit: true)!;
        }

        public IEnumerable<PropertyInfo> GetProperties<T>()
        {
            return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                   .Where(p => p.GetCustomAttribute<ColumnAttribute>(inherit: true) != null)
                   .OrderBy(p => p.GetCustomAttribute<ColumnAttribute>(inherit: true)!.Index);
        }
    }
}
