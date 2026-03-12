namespace NExporter.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Title { get; }
        public int Index { get; }

        public ColumnAttribute(string title, int index)
        {
            Title = title;
            Index = index;
        }
    }
}
