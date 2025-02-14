using AzureJobs.Extensions;

var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .Build();

var builder = Host.CreateDefaultBuilder();

builder
    .ConfigureWebJobs(b =>
    {
        b
        .AddAzureStorageCoreServices()
        .AddTimers();
    })
    .AddServices()
    .UseConsoleLifetime();

var host = builder.Build();

using (host)
{
    await host.RunAsync();
}