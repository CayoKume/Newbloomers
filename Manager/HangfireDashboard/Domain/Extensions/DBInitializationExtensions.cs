using Domain.IntegrationsCore.Entities.Parameters;
using HangfireDashboard.Domain.Entites;
using HangfireDashboard.Infrastructure.Repository;

namespace HangfireDashboard.Domain.Extensions
{
    public static class DBInitializationExtensions
    {
        private static IConfiguration? _configuration;

        public static async Task<WebApplication> DatabaseInitialization(this WebApplication app, IConfiguration configuration)
        {
            _configuration = configuration;

            var serverParameter = new ServerParameter() { 
                serverName = _configuration.GetSection("ConfigureServer").GetSection("ServerName").Value,
                linxMicrovixDatabaseName = _configuration.GetSection("ConfigureServer").GetSection("LinxMicrovixDatabaseName").Value,
                linxCommerceDatabaseName = _configuration.GetSection("ConfigureServer").GetSection("LinxCommerceDatabaseName").Value,
                generalDatabaseName = _configuration.GetSection("ConfigureServer").GetSection("GeneralDatabaseName").Value,
            };

            using var scope = app.Services.CreateScope();

            #region Databases Initialization
            var context = scope.ServiceProvider.GetRequiredService<IDBInitializationRepository<ServerParameter>>();

            await context.CreateDatabaseIfNotExists(
                projectName: serverParameter.serverName, 
                databaseName: serverParameter.generalDatabaseName
            );
            await context.CreateDatabaseIfNotExists(
                projectName: serverParameter.serverName, 
                databaseName: serverParameter.linxMicrovixDatabaseName
            );
            await context.CreateDatabaseIfNotExists(
                projectName: serverParameter.serverName, 
                databaseName: serverParameter.linxCommerceDatabaseName
            ); 
            #endregion

            #region Linx Microvix Integrations
            var linxAPIParam = scope.ServiceProvider.GetRequiredService<IDBInitializationRepository<LinxAPIParam>>();
            var linxAPILog = scope.ServiceProvider.GetRequiredService<IDBInitializationRepository<LinxAPILog>>();

            var linxMicrovixParametersTableName = _configuration.GetSection("LinxMicrovix").GetSection("ProjectParametersTableName").Value;
            var linxMicrovixParametersLogTableName = _configuration.GetSection("LinxMicrovix").GetSection("ProjectParametersLogTableName").Value;

            await linxAPIParam.CreateParametersDataTableIfNotExists(
                projectName: serverParameter.serverName,
                databaseName: serverParameter.linxMicrovixDatabaseName,
                tableName: linxMicrovixParametersTableName
            );

            await linxAPILog.CreateParametersDataTableIfNotExists(
                projectName: serverParameter.serverName,
                databaseName: serverParameter.linxMicrovixDatabaseName,
                tableName: linxMicrovixParametersLogTableName
            ); 
            #endregion

            return app;
        }
    }
}
