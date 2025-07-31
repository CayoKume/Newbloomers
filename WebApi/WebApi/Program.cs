using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddArchitectures();

var app = builder.Build();

app.UseApplication();

app.MapControllers();

app.Run();