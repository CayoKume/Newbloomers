using Dapper;
using Infrastructure.Core.Connections.SQLServer;
using ExecuteCancellationOrder = Domain.WebApi.Models.ExecuteCancellationOrder;
using Application.WebApi.Interfaces.Handlers.Commands;
using Domain.WebApi.Interfaces.Repositorys;
using Domain.WebApi.Models;

namespace Repositorys
{
    public class ExecuteCancellationRepository : IExecuteCancellationRepository
    {
        private readonly ISQLServerConnection _conn;
        private readonly IExecuteCancellationCommandHandler _executeCancellationCommandHandler;

        public ExecuteCancellationRepository(ISQLServerConnection conn, IExecuteCancellationCommandHandler executeCancellationCommandHandler) =>
            (_conn, _executeCancellationCommandHandler) = (conn, executeCancellationCommandHandler);

        public async Task<IEnumerable<ExecuteCancellationOrder>> GetOrdersToCancel(string serie, string doc_company)
        {
            var sql = _executeCancellationCommandHandler.CreateGetOrdersToCancelQuery(serie, doc_company);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<ExecuteCancellationOrder, Client, ExecuteCancellationProduct, ExecuteCancellationOrder>(sql, (pedido, cliente, produto) =>
                    {
                        pedido.client = cliente;
                        pedido.itens.Add(produto);
                        return pedido;
                    }, splitOn: "cod_client, cod_product");

                    var pedidos = result.GroupBy(p => p.number).Select(g =>
                    {
                        var groupedOrder = g.First();
                        groupedOrder.itens = g.Select(p => p.itens.Single()).ToList();
                        return groupedOrder;
                    });

                    return pedidos;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"MiniWms [ExecuteCancellation] - GetOrdersToCancel - Erro ao obter pedido na tabela TB_NB_CANCELAMENTO_PEDIDOS  - {ex.Message}");
            }
        }

        public async Task<Dictionary<int, string>> GetReasons()
        {
            var sql = _executeCancellationCommandHandler.CreateGetReasonsQuery();

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
                throw new Exception($"MiniWms [ExecuteCancellation] - GetReasons - Erro ao obter motivos dos cancelamentos - {ex.Message}");
            }
        }

        public async Task<bool> UpdateDateCanceled(string number, string suporte, string inputObs, int motivo)
        {
            var sql = _executeCancellationCommandHandler.CreateUpdateDateCanceledQuery(number, suporte, inputObs, motivo);

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
                throw new Exception($"MiniWms [ExecuteCancellation] - UpdateDateCanceled - Erro ao atualizar data de cancelamento do pedido {number} na tabela TB_NB_CANCELAMENTO_PEDIDOS  - {ex.Message}");
            }
        }
    }
}
