using Application.Core.Handlers;
using Application.Core.Interfaces;
using Application.Core.Services;
using Domain.Core.Interfaces;
using Infrastructure.Core.Connections.SQLServer;
using Infrastructure.Core.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Core.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedCoreServices(this IServiceCollection services)
        {
            services.AddScoped<ISQLServerConnection, SQLServerConnection>();
            services.AddScoped<ICoreRepository, CoreRepository>();

            services.AddScoped<ILoggerService, LoggerService>();

            services.AddScoped<IExceptionHandler, APIExceptionHandler>();
            services.AddScoped<IExceptionHandler, SqlExceptionHandler>();
            services.AddScoped<IExceptionHandler, GeneralExceptionHandler>();
            services.AddScoped<IExceptionHandler, ExceptionHandler>();

            return services;
        }
    }
}
