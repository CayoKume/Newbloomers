using Dapper;
using Domain.IntegrationsCore.Interfaces;
using Domain.Movidesk.Entities;
using Domain.Movidesk.Interfaces.Repositorys;
using Infrastructure.IntegrationsCore.Connections.SQLServer;

namespace Infrastructure.Movidesk.Repositorys
{
    public class MovideskRepository : IMovideskRepository
    {
        private readonly ISQLServerConnection? _sqlServerConnection;
        private readonly IIntegrationsCoreRepository? _integrationsCoreRepository;

        public MovideskRepository(ISQLServerConnection? sqlServerConnection, IIntegrationsCoreRepository? integrationsCoreRepository) =>
            (_sqlServerConnection, _integrationsCoreRepository) = (sqlServerConnection, integrationsCoreRepository);

        public async Task<Parameters> GetTokenAsync()
        {
            string? sql = @$"SELECT DISTINCT
                     TOKEN
                     FROM GENERAL.PARAMETROS_MOVIDESK";

            using (var conn = _sqlServerConnection.GetIDbConnection())
            {
                return await conn.QueryFirstAsync<Parameters>(sql);
            }
        }
    }
}
