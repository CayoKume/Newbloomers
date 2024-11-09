using WebJobsApplication.Domain.Entites;
using IntegrationsCore.Domain.Entities.Parameters;
using WebJobsApplication.Infrastructure.Repository.Base;
using WebJobsApplication.Infrastructure.Connections.LinxMicrovix;

namespace WebJobsApplication.Domain.Extensions
{
    public static class DBInitializationExtensions
    {
        private static IConfigurationRoot? _configuration;

        public static async Task DatabaseInitialization(this IHost host, IConfigurationRoot configuration)
        {
            _configuration = configuration;

            var serverParameter = new ServerParameter() { 
                serverName = _configuration.GetSection("ConfigureServer").GetSection("ServerName").Value,
                linxMicrovixDatabaseName = _configuration.GetSection("ConfigureServer").GetSection("LinxMicrovixDatabaseName").Value,
                linxCommerceDatabaseName = _configuration.GetSection("ConfigureServer").GetSection("LinxCommerceDatabaseName").Value,
                generalDatabaseName = _configuration.GetSection("ConfigureServer").GetSection("GeneralDatabaseName").Value,
            };

            using var scope = host.Services.CreateScope();

            #region Databases Initialization
            var context = scope.ServiceProvider.GetRequiredService<IDBInitializationRepository<ServerParameter>>();

            //await context.CreateDatabaseIfNotExists(
            //    projectName: serverParameter.serverName, 
            //    databaseName: serverParameter.generalDatabaseName
            //);
            //await context.CreateDatabaseIfNotExists(
            //    projectName: serverParameter.serverName, 
            //    databaseName: serverParameter.linxMicrovixDatabaseName
            //);
            //await context.CreateDatabaseIfNotExists(
            //    projectName: serverParameter.serverName, 
            //    databaseName: serverParameter.linxCommerceDatabaseName
            //); 
            #endregion

            #region Linx Microvix Integrations - Parameters
            var linxAPIParam = scope.ServiceProvider.GetRequiredService<ILinxMicrovixRepository<LinxAPIParam>>();
            var linxAPILog = scope.ServiceProvider.GetRequiredService<ILinxMicrovixRepository<LinxAPILog>>();

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
        }
    }
}
