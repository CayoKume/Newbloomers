using Application.WebApi.Interfaces.Handlers.Commands;
using Domain.WebApi.Interfaces.Repositorys;
using Dapper;
using Domain.WebApi.Models;
using Infrastructure.Core.Connections.SQLServer;
using System.Data;
using System.Threading;
using Domain.Wms.Models;

namespace Infrastructure.WebApi.Repositorys
{
    public class DeliveryListRepository : IDeliveryListRepository
    {
        private readonly ISQLServerConnection _conn;
        private readonly IDeliveryListCommandHandler _deliveryListCommandHandler;

        public DeliveryListRepository(ISQLServerConnection conn, IDeliveryListCommandHandler deliveryListCommandHandler) =>
            (_conn, _deliveryListCommandHandler) = (conn, deliveryListCommandHandler);

        public async Task<Order?> GetOrderShipped(string nr_pedido, string serie, string cnpj_emp, string transportadora)
        {
            var sql = _deliveryListCommandHandler.CreateGetOrderShippedQuery(nr_pedido, serie, cnpj_emp, transportadora);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<Order, Client, ShippingCompany, Invoice, Company, Order>(sql, (pedido, cliente, transportadora, notaFiscal, empresa) =>
                    {
                        pedido.client = cliente;
                        pedido.shippingCompany = transportadora;
                        pedido.invoice = notaFiscal;
                        pedido.company = empresa;
                        return pedido;
                    }, splitOn: "cod_client, cod_shippingCompany, number_nf, doc_company");

                    return result.First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [DeliveryList] - GetOrderShipped - Erro ao obter pedido: {nr_pedido} na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<IEnumerable<Order>?> GetOrdersShipped(string cod_transportadora, string cnpj_emp, string serie_pedido, string data_inicial, string data_final)
        {
            var sql = _deliveryListCommandHandler.CreateGetOrdersShippedQuery(cod_transportadora, cnpj_emp, serie_pedido, data_inicial, data_final);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    return await conn.QueryAsync<Order, Client, ShippingCompany, Invoice, Company, Order>(sql, (pedido, cliente, transportadora, notaFiscal, empresa) =>
                            {
                                pedido.client = cliente;
                                pedido.shippingCompany = transportadora;
                                pedido.invoice = notaFiscal;
                                pedido.company = empresa;
                                return pedido;
                            }, splitOn: "cod_client, cod_shippingCompany, number_nf, doc_company");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Imprime Romaneio] - GetPedidosEnviados - Erro ao obter pedidos na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<IEnumerable<DeliveryList>> GetDeliveryLists(string cod_transportadora, string cnpj_emp, string data_inicial, string data_final)
        {
            var sql = _deliveryListCommandHandler.CreateGetDeliveryListsQuery(cod_transportadora, cnpj_emp, data_inicial, data_final);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    return await conn.QueryAsync<DeliveryList>(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [DeliveryList] - GetDeliveryLists - Erro ao obter listas de entrega - {ex.Message}");
            }
        }

        public async Task<bool?> InsertPickedsDates(Guid guid, string deliveryListName, string carrier, IEnumerable<Order> orders)
        {
            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var sql = @$"INSERT INTO azure.newbloomers.[webapplication].[DeliveryLists]
                            ([uniqueidentifier], [name], [carrier], [printedAt]) 
                            Values 
                            (@uniqueidentifier, @name, @carrier, GETDATE())";

                    await conn.ExecuteAsync(sql: sql, new { uniqueidentifier = $"{guid}", name = $"{deliveryListName}", carrier = $"{carrier}", printedAt = DateTime.Now }, commandTimeout: 360);

                    foreach (var order in orders)
                    {
                        var _sql = @$"INSERT INTO azure.newbloomers.[webapplication].[DeliveryListsOrders]
                            ([uniqueidentifier], [pedido]) 
                            Values 
                            (@uniqueidentifier, @pedido)";

                        await conn.ExecuteAsync(sql: _sql, new { uniqueidentifier = $"{guid}", pedido = $"{order.number}" }, commandTimeout: 360);
                    }

                    //var result = await conn.ExecuteAsync($"exec azure.newbloomers.[general].[p_DeliveryLists_Sincronizacao]");

                    //var result = await conn.ExecuteAsync($"exec azure.newbloomers.[general].[p_DeliveryListsOrders_Sincronizacao]");
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
