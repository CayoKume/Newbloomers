using Application.WebApi.Interfaces.Handlers.Commands;
using Domain.WebApi.Interfaces.Repositorys;
using Dapper;
using Infrastructure.Core.Connections.SQLServer;
using Domain.Wms.Models;

namespace Infrastructure.WebApi.Repositorys
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ISQLServerConnection _conn;
        private readonly IHomeCommandHandler _homeCommandHandler;

        public HomeRepository(ISQLServerConnection conn, IHomeCommandHandler homeCommandHandler) =>
            (_conn, _homeCommandHandler) = (conn, homeCommandHandler);

        public async Task<IEnumerable<HomeOrder>?> GetPickupOrders(string doc_company)
        {
            var sql = _homeCommandHandler.CreateGetPickupOrdersQuery(doc_company);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    return await conn.QueryAsync<HomeOrder>(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Home] - GetPickupOrders - Erro ao obter pedidos na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }
    }
}
