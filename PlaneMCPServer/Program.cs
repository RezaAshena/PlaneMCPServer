using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.Sources.Clear();

builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

var planeApiKey = builder.Configuration["PlaneAPIKey"] ?? throw new InvalidOperationException("Plane API key is not configured.");
var baseUrl = builder.Configuration["BaseUrl"] ?? throw new InvalidOperationException("Base Url is not configured.");
var WorkSpace = builder.Configuration["Workspace"] ?? throw new InvalidOperationException("Work space is not configured.");
var projectId = builder.Configuration["projectid"] ?? throw new InvalidOperationException("project id is not configured.");
