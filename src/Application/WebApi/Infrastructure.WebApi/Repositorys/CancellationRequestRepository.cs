using Dapper;
using Infrastructure.Core.Connections.SQLServer;
using System.Drawing;
using Application.WebApi.Interfaces.Handlers.Commands;
using Domain.WebApi.Interfaces.Repositorys;
using Domain.WebApi.Models;

namespace Repositorys
{
    public class CancellationRequestRepository : ICancellationRequestRepository
    {
        private readonly ISQLServerConnection _conn;
        private readonly ICancellationRequestCommandHandler _cancellationRequestCommandHandler;

        public CancellationRequestRepository(ISQLServerConnection conn, ICancellationRequestCommandHandler cancellationRequestCommandHandler) =>
            (_conn, _cancellationRequestCommandHandler) = (conn, cancellationRequestCommandHandler);

        public async Task<bool> CreateCancellationRequest(CancellationRequestOrder order)
        {
            var sql = _cancellationRequestCommandHandler.CreateCancellationRequestQuery(order);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.ExecuteAsync(sql);
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [CancellationRequest] - CreateCancellationRequest - Erro ao criar solicitação de cancelamento do pedido: {order.number}  - {ex.Message}");
            }
        }

        public async Task<CancellationRequestOrder> GetOrderToCancel(string number, string serie, string doc_company)
        {
            var sql = _cancellationRequestCommandHandler.CreateGetOrderToCancelQuery(number, serie, doc_company);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<CancellationRequestOrder, CancellationRequestProduct, CancellationRequestOrder>(sql, (pedido, produto) =>
                    {
                        pedido.itens.Add(produto);
                        return pedido;
                    }, splitOn: "cod_product");

                    var pedido = result.GroupBy(p => p.number).Select(g =>
                    {
                        var groupedOrder = g.First();
                        groupedOrder.itens = g.Select(p => p.itens.Single()).ToList();
                        return groupedOrder;
                    });

                    return pedido.First();
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"MiniWms [CancellationRequest] - GetOrder - Erro ao obter pedido na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<Dictionary<int, string>> GetReasons()
        {
            var sql = _cancellationRequestCommandHandler.CreateGetReasonsQuery();

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<KeyValuePair<int, string>>(sql);
                    return result.ToDictionary(pair => pair.Key, pair => pair.Value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [CancellationRequest] - GetReasons - Erro ao obter motivos dos cancelamentos - {ex.Message}");
            }
        }
    }
}
