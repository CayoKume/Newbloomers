using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Microsoft.Extensions.DependencyInjection;

namespace HangfireDashboard.Domain.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddScopedSQLServerConnection(this IServiceCollection services)
        {
            services.AddScoped<ISQLServerConnection, SQLServerConnection>();

            //services.AddScoped<IDBInitializationRepository<ServerParameter>, DBInitializationRepository<ServerParameter>>();
            //services.AddScoped<IDBInitializationRepository<LinxAPIParam>, DBInitializationRepository<LinxAPIParam>>();
            //services.AddScoped<IDBInitializationRepository<LinxAPILog>, DBInitializationRepository<LinxAPILog>>();

            return services;
        }
    }
}
