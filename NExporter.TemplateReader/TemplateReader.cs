using NExporter.Models.DTO;
using NExporter.Models.Enumerations;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NExporter.TemplateReader
{
    public class TemplateReader
    {
        public static TemplateDTO Read(TemplateType type)
        {
            ResourceManager rm = new ResourceManager($"NExporter.TemplateReader.Resources.{type.ToString()}", Assembly.GetExecutingAssembly());

            Dictionary<string, string> resource = new();

            foreach (DictionaryEntry entry in rm.GetResourceSet(CultureInfo.CurrentUICulture, true, true))
            {
                resource.Add(entry.Key.ToString(), entry.Value?.ToString());
            }

            return new TemplateDTO
            {
                TableInnerBorderColor = resource.GetValueOrDefault("TableInnerBorderColor", string.Empty),
                TableOuterBorderColor = resource.GetValueOrDefault("TableOuterBorderColor", string.Empty),
                TextColor = resource.GetValueOrDefault("TextColor", string.Empty)
            };
        }
    }
}
