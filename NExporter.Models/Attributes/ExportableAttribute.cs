using NExporter.Models.Enumerations;

namespace NExporter.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportableAttribute : Attribute
    {
        public string SheetName { get; }
        public TemplateType TemplateType { get; }

        public ExportableAttribute(string sheetName, TemplateType templateType)
        {
            SheetName = sheetName;
            TemplateType = templateType;
        }
    }
}
