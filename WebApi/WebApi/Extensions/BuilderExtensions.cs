using Infrastructure.Core.DependencyInjection;
using Infrastructure.WebApi;

namespace WebApi.Extensions
{
    public static class BuilderExtensions
    {
        public static WebApplicationBuilder AddArchitectures(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();
            builder.Services.AddScopedCoreServices();
            builder.Services.AddScopedWmsServices();

            return builder;
        }
    }
}
