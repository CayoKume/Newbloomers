using Application.IntegrationsCore.Handlers;
using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Domain.IntegrationsCore.Interfaces;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Infrastructure.IntegrationsCore.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IntegrationsCore.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedIntegrationsCoreServices(this IServiceCollection services)
        {
            services.AddScoped<ISQLServerConnection, SQLServerConnection>();
            services.AddScoped<IIntegrationsCoreRepository, IntegrationsCoreRepository>();

            services.AddScoped<ILoggerService, LoggerService>();

            services.AddScoped<IExceptionHandler, APIExceptionHandler>();
            services.AddScoped<IExceptionHandler, SqlExceptionHandler>();
            services.AddScoped<IExceptionHandler, GeneralExceptionHandler>();
            services.AddScoped<IExceptionHandler, ExceptionHandler>();

            return services;
        }
    }
}
