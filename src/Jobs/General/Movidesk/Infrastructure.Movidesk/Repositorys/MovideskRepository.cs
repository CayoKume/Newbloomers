using Dapper;
using Domain.Core.Interfaces;
using Domain.Movidesk.Entities;
using Domain.Movidesk.Interfaces.Repositorys;
using Infrastructure.Core.Connections.SQLServer;

namespace Infrastructure.Movidesk.Repositorys
{
    public class MovideskRepository : IMovideskRepository
    {
        private readonly ISQLServerConnection? _sqlServerConnection;
        private readonly ICoreRepository? _coreRepository;

        public MovideskRepository(ISQLServerConnection? sqlServerConnection, ICoreRepository? coreRepository) =>
            (_sqlServerConnection, _coreRepository) = (sqlServerConnection, coreRepository);

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
