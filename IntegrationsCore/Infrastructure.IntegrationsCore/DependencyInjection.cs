using Domain.IntegrationsCore.Interfaces;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Infrastructure.IntegrationsCore.Repositorys.Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IntegrationsCore.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedSQLServerConnection(this IServiceCollection services)
        {
            services.AddScoped<ISQLServerConnection, SQLServerConnection>();
            services.AddScoped<IIntegrationsCoreRepository, IntegrationsCoreRepository>();

            return services;
        }
    }
}
