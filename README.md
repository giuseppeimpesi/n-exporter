# n-exporter

n-exporter is a lightweight C# library that simplifies exporting collections of data to different formats.

It is designed to be simple, extensible, and fully compatible with the .NET dependency injection system.  
The library uses a factory pattern to resolve the appropriate exporter at runtime.

---

## Features

- Simple data export from `IEnumerable<T>`
- Multiple export formats (CSV, XLS, JSON)
- Clean factory-based architecture
- Easy integration with .NET Dependency Injection
- Extensible with custom exporters

---

## Getting Started

### 1. Register exporters

Register the exporters in the dependency injection container as **transient services**.

```csharp
services.AddTransient<IExporter, CsvExporter>();
services.AddTransient<IExporter, XlsExporter>();
services.AddTransient<IExporter, JsonExporter>();
```
### 2. Register exporter factory

Then register the exporter factory in the dependency injection container as **singleton service**.

```csharp
services.AddSingleton<IExporterFactory, ExporterFactory>();
```

### 3. Inject exporter factory

Inject exporter factory into your service and export your data

```csharp
public class YourService
{
    private readonly IExporterFactory _exporterFactory;

    public YourService(IExporterFactory exporterFactory)
    {
        _exporterFactory = exporterFactory;
    }

    public byte[] ExportDummyData()
    {
        List<Dummy> data = new List<Dummy>
        {
            new Dummy { Id = Guid.NewGuid(), Name = "Alice", Age = 30, BirthDate = new DateTime(1993, 1, 1) },
            new Dummy { Id = Guid.NewGuid(), Name = "Bob", Age = 25, BirthDate = new DateTime(1998, 2, 2) },
            new Dummy { Id = Guid.NewGuid(), Name = "Charlie", Age = 35, BirthDate = new DateTime(1988, 3, 3) }
        };

        byte[] file = _exporterFactory
            .Get(ExportType.Xls)
            .Export<Dummy>(data);

        return file;
    }
}
```

