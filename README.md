# TimberLogger
[![NuGet](https://img.shields.io/nuget/v/TimberLogger.svg)](https://www.nuget.org/packages/TimberLogger/)

TimberLogger is a .NET Core logger provider to push your logs to [Timber](https://timber.io).

## Usage
### Generate API key
To get an API key, just create a new app. Under *Language Type* and *Platform Type*, select _Other_. You will now get a page that contains your API key.

## Install package
Run the following command in your project root: `dotnet add package TimberLogger`

### Add provider to project
Instantiate the provider with your API key:

```csharp
// ...
using TimberClient.Configuration;
using TimberClient.Extensions;

public class Startup
{
  // ...
  public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
  {
    // ...

    // Set your API token via your prefered way of configuration
    string apiToken = "[Your API token here]";

    // Add TimberLogger to your project as a logger provider
    loggerFactory.AddTimberLogging(new TimberLoggerConfiguration
    {
      ApiKey = apiToken,
      LogLevel = LogLevel.Information
    });

    // ...
  }
}
```

Now just get the logger the way you're used to:

```csharp
public class Foo : Controller
{
  private readonly ILogger<Foo> _logger;

  public FooController(ILogger<Foo> logger)
  {
    _logger = logger;
  }

  public void DoFoo()
  {
    _logger.LogInformation("Doing foo!");
  }
}
```

## Configuration
The `TimberLoggerConfiguration` object offers some basic configuration options:

```csharp
loggerFactory.AddTimberLogging(new TimberLoggerConfiguration
{
  // Your API token
  ApiKey = "", 

  // Default Timber URI
  TimberUrl = "https://logs.timber.io", 

  // Set the minimum loglevel, by default this is set to LogLevel.Warning
  LogLevel = LogLevel.Warning,

  // Set the format of the log as it appears in Timber:
  //   {0}: The category. If your logger is an instance of ILogger<FooController>, the category appears as 'FooController'
  //   {1}: The message
  // By default this would for example be: "[FooController] received request"
  Format = "[{0}] {1}"
})
```