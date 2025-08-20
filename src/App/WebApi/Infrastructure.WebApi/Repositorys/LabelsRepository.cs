using Dapper;
using Infrastructure.Core.Connections.SQLServer;
using LabelsOrder = Domain.WebApi.Models.LabelsOrder;
using Application.WebApi.Interfaces.Handlers.Commands;
using Domain.WebApi.Models;
using Domain.WebApi.Interfaces.Repositorys;

namespace Repositorys
{
    public class LabelsRepository : ILabelsRepository
    {
        private readonly ISQLServerConnection _conn;
        private readonly ILabelsCommandHandler _labelsCommandHandler;

        public LabelsRepository(ISQLServerConnection conn, ILabelsCommandHandler labelsCommandHandler) =>
            (_conn, _labelsCommandHandler) = (conn, labelsCommandHandler);

        public async Task<LabelsOrder> GetOrdersToPresent(string cnpj_emp, string serie, string nr_pedido)
        {
            var sql = _labelsCommandHandler.CreateGetOrdersToPresentQuery(cnpj_emp, serie, nr_pedido);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<LabelsOrder, Client, Company, Invoice, LabelsOrder>(sql, (pedido, cliente, empresa, notaFiscal) =>
                    {
                        pedido.client = cliente;
                        pedido.company = empresa;
                        pedido.invoice = notaFiscal;
                        return pedido;
                    }, splitOn: "cod_client, cod_company, number_nf");

                    return result.First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Labels] - GetOrdersToPresent - Erro ao obter pedidos na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<IEnumerable<LabelsOrder>> GetOrdersToPrint(string cnpj_emp, string serie, string data_inicial, string data_final)
        {
            var sql = _labelsCommandHandler.CreateGetOrdersToPrintQuery(cnpj_emp, serie, data_inicial, data_final);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    return await conn.QueryAsync<LabelsOrder, Client, ShippingCompany, Company, Invoice, LabelsOrder>(sql, (pedido, cliente, transportadora, empresa, notaFiscal) =>
                    {
                        pedido.client = cliente;
                        pedido.shippingCompany = transportadora;
                        pedido.company = empresa;
                        pedido.invoice = notaFiscal;
                        return pedido;
                    }, splitOn: "cod_client, cod_shippingCompany, cod_company, number_nf");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Labels] - GetOrdersToPrint - Erro ao obter pedidos na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<LabelsOrder> GetOrderToPrint(string cnpj_emp, string serie, string nr_pedido)
        {
            var sql = _labelsCommandHandler.CreateGetOrderToPrintQuery(cnpj_emp, serie, nr_pedido);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<LabelsOrder, Client, ShippingCompany, Company, Invoice, LabelsOrder>(sql, (pedido, cliente, transportadora, empresa, notaFiscal) =>
                    {
                        pedido.client = cliente;
                        pedido.shippingCompany = transportadora;
                        pedido.company = empresa;
                        pedido.invoice = notaFiscal;
                        return pedido;
                    }, splitOn: "cod_client, cod_shippingCompany, cod_company, number_nf");

                    return result.First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Labels] - GetOrderToPrint - Erro ao obter pedido: {nr_pedido} na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<int> UpdatePrintedFlag(string nr_pedido)
        {
            var sql = _labelsCommandHandler.CreateUpdatePrintedFlagQuery(nr_pedido);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    return await conn.ExecuteAsync(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Labels] - UpdatePrintedFlag - Erro ao atualizar status da etiqueta do pedido: {nr_pedido} como impressa na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }
    }
}
