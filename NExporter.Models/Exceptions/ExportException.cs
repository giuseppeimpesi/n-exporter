namespace NExporter.Models.Exceptions
{
    public class ExportException : Exception
    {
        public ExportException() : base() { }
        public ExportException(string message) : base(message) { }
        public ExportException(string message, Exception inner) : base(message, inner) { }
    }
}
