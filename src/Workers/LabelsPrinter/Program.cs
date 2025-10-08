using Infrastructure.Core.DependencyInjection;
using LabelsPrinter;
using LabelsPrinter.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);
builder.Services
    .AddScopedCoreServices()
    .AddScopedServices()
    .AddHostedService<Worker>();

var host = builder.Build();
host.Run();
