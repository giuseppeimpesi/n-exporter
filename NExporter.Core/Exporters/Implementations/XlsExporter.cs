using NExporter.Models.Attributes;
using NExporter.Models.Enumerations;
using NExporter.Models.Exceptions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Reflection;

namespace NExporter.Core.Exporters.Implementations
{
    public sealed class XlsExporter : BaseExporter, IExporter
    {
        public ExportType ExportType => ExportType.Xls;

        public byte[] Export<T>(IEnumerable<T> data)
        {
            try
            {
                if (data == null || !data.Any())
                    throw new ArgumentException("Data collection cannot be null or empty");

                if (!IsExportable<T>())
                    throw new InvalidOperationException($"Type {typeof(T).Name} is not exportable. Ensure it has the [Exportable] attribute");

                IEnumerable<PropertyInfo> properties = GetProperties<T>();

                if (properties == null || !properties.Any())
                    throw new InvalidOperationException($"Type {typeof(T).Name} does not have any properties marked with [Column] attribute");

                ExportableAttribute attribute = GetExportableAttribute<T>();

                using (IWorkbook workbook = new XSSFWorkbook())
                {
                    ISheet sheet = workbook.CreateSheet(attribute.SheetName);

                    // Create header row

                    IRow header = sheet.CreateRow(0);

                    for (int i = 0; i < properties.Count(); i++)
                    {
                        ColumnAttribute columnAttribute = properties.ElementAt(i).GetCustomAttribute<ColumnAttribute>(inherit: true)!;

                        header.CreateCell(i).SetCellValue(columnAttribute.Title);
                    }

                    // Create data rows

                    for (int i = 0; i < data.Count(); i++)
                    {
                        IRow row = sheet.CreateRow(i + 1);

                        T item = data.ElementAt(i);

                        for (int j = 0; j < properties.Count(); j++)
                        {
                            ICell cell = row.CreateCell(j);

                            cell.SetCellValue(properties.ElementAt(j).GetValue(item) as dynamic);
                        }
                    }

                    // Auto-size columns

                    for (int x = 0; x < properties.Count(); x++)
                    {
                        sheet.AutoSizeColumn(x);
                    }

                    using (MemoryStream stream = new MemoryStream())
                    {
                        workbook.Write(stream);

                        return stream.ToArray();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new ExportException("Error occurred during exporting data", ex);
            }
        }
    }
}
