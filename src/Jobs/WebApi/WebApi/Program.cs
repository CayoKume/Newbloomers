using Hangfire.IO.Extensions;

var builder = WebApplication.CreateBuilder(args);
var serverName = builder.Configuration.GetSection("ConfigureServer").GetSection("ServerName").Value;

ConfigurationHelperExtensions.Initialize(builder.Configuration);

builder
    .AddArchitectures()
    .AddServices();

var app = builder.Build();

app.UseApplication(serverName);

#if DEBUG
app.MapControllers();
#endif

app.Run();