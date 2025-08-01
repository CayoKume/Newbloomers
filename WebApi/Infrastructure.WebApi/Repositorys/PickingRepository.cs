using Application.WebApi.Interfaces.Handlers.Commands;
using Domain.WebApi.Interfaces.Repositorys;
using Dapper;
using Domain.WebApi.Models;
using Infrastructure.Core.Connections.SQLServer;
using Newtonsoft.Json;
using Domain.Wms.Models;

namespace Infrastructure.WebApi.Repositorys
{
    public class PickingRepository : IPickingRepository
    {
        private readonly ISQLServerConnection _conn;
        private readonly IPickingCommandHandler _pickingCommandHandler;

        public PickingRepository(ISQLServerConnection conn, IPickingCommandHandler pickingCommandHandler) =>
            (_conn, _pickingCommandHandler) = (conn, pickingCommandHandler);

        public async Task<List<ShippingCompany>?> GetShippingCompanys()
        {
            var sql = _pickingCommandHandler.CreateGetShippingCompanysQuery();

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<ShippingCompany>(sql);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Picking] - GetShippingCompanys - Erro ao obter transportadoras da tabela LinxClientesFornec_trusted  - {ex.Message}");
            }
        }

        public async Task<PickingOrder?> GetUnpickedOrder(string cnpj_emp, string serie, string nr_pedido)
        {
            var sql = _pickingCommandHandler.CreateGetUnpickedOrderQuery(cnpj_emp, serie, nr_pedido);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<PickingOrder, Client, ShippingCompany, Invoice, PickingProduct, PickingOrder>(sql, (pedido, cliente, transportadora, nota_fiscal, produto) =>
                    {
                        pedido.client = cliente;
                        pedido.shippingCompany = transportadora;
                        pedido.invoice = nota_fiscal;
                        pedido.itens.Add(produto);
                        return pedido;
                    }, splitOn: "cod_client, cod_shippingCompany, amount_nf, cod_product");

                    var pedidos = result.GroupBy(p => p.number).Select(g =>
                    {
                        var groupedOrder = g.First();
                        groupedOrder.itens = g.Select(p => p.itens.Single()).ToList();
                        return groupedOrder;
                    });

                    return pedidos.First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Picking] - GetUnpickedOrder - Erro ao obter pedido: {nr_pedido} na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<List<PickingOrder>?> GetUnpickedOrders(string cnpj_emp, string serie_pedido, string data_inicial, string data_final)
        {
            var sql = _pickingCommandHandler.CreateGetUnpickedOrdersQuery(cnpj_emp, serie_pedido, data_inicial, data_final);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<PickingOrder, Client, ShippingCompany, Invoice, PickingProduct, PickingOrder>(sql, (pedido, cliente, transportadora, nota_fiscal, produto) =>
                    {
                        pedido.client = cliente;
                        pedido.shippingCompany = transportadora;
                        pedido.invoice = nota_fiscal;
                        pedido.itens.Add(produto);
                        return pedido;
                    }, splitOn: "cod_client, cod_shippingCompany, amount_nf, cod_product");

                    var pedidos = result.GroupBy(p => p.number).Select(g =>
                    {
                        var groupedOrder = g.First();
                        groupedOrder.itens = g.Select(p => p.itens.Single()).ToList();
                        return groupedOrder;
                    });

                    return pedidos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Confere Pedido] - GetPedidosNaoConferidos - Erro ao obter pedidos na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<PickingOrder?> GetUnpickedOrderToPrint(string cnpj_emp, string serie, string nr_pedido)
        {
            string sql = $@"SELECT DISTINCT
                         A.DOCUMENTO AS NUMBER,
                         A.NB_CFOP_PEDIDO AS CFOP,
                         C.[1] AS OBS,
                         D.NOME_VENDEDOR AS SELLER,
                         IIF(A.NB_PARA_PRESENTE = 'S', 'SIM', 'NÃO') AS PRESENT,
                         A.NB_VALOR_PEDIDO AS AMOUNT,

                         A.NB_NOME_REMETENTE AS NAME_COMPANY,
                         A.NB_ENDERECO_REMETENTE AS ADDRESS_COMPANY,
                         A.NB_NUMERO_RUA_REMETENTE AS STREET_NUMBER_COMPANY,
                         A.NB_COMPLEMENTO_END_REMETENTE AS COMPLEMENT_ADDRESS_COMPANY,
                         A.NB_BAIRRO_REMETENTE AS NEIGHBORHOOD_COMPANY,
                         A.NB_CEP_REMETENTE AS ZIP_CODE_COMPANY,
                         A.NB_CIDADE_REMETENTE AS CITY_COMPANY,
                         A.NB_UF_REMETENTE AS UF_COMPANY,
                         A.NB_FONE_REMETENTE AS FONE_COMPANY,
                         A.NB_DOC_REMETENTE AS DOC_COMPANY,
                         A.NB_INSCRICAO_ESTADUAL_REMETENTE AS STATE_REGISTRATION_COMPANY,
                         
                         A.NB_RAZAO_CLIENTE AS REASON_CLIENT,
                         A.NB_CODIGO_CLIENTE AS COD_CLIENT,
                         A.NB_ENDERECO_CLIENTE AS ADDRESS_CLIENT,
                         A.NB_BAIRRO_CLIENTE AS NEIGHBORHOOD_CLIENT,
                         A.NB_NUMERO_RUA_CLIENTE AS STREET_NUMBER_CLIENT,
                         A.NB_COMPLEMENTO_END_CLIENTE AS COMPLEMENT_ADDRESS_CLIENT,
                         A.NB_CEP AS ZIP_CODE_CLIENT,
                         A.NB_EMAIL_CLIENTE AS EMAIL_CLIENT,
                         A.NB_DOC_CLIENTE AS DOC_CLIENT,
                         A.NB_INSCRICAO_ESTADUAL_CLIENTE AS STATE_REGISTRATION_CLIENT,
                         
                         A.NB_TRANSPORTADORA AS COD_SHIPPINGCOMPANY,
                         A.NB_RAZAO_TRANSPORTADORA AS REASON_SHIPPINGCOMPANY,

                         B.IDITEM AS IDITEM,
                         B.CODIGO_BARRA AS COD_PRODUCT,
                         B.DESCRICAO AS DESCRIPTION_PRODUCT,
                         B.NB_SKU_PRODUTO AS SKU_PRODUCT,
                         B.QTDE AS QUANTITY_PRODUCT,
                         B.NB_VALOR_UNITARIO_PRODUTO AS UNITARY_VALUE_PRODUCT,
                         B.NB_VALOR_TOTAL_PRODUTO AS AMOUNT_PRODUCT
                         
                         [0]";

            if (nr_pedido.Contains("-VD") || nr_pedido.Contains("-LJ"))
            {
                sql = sql.Replace("[1]", "OBS").Replace("[0]", $@"FROM GENERAL..IT4_WMS_DOCUMENTO A (NOLOCK)
                                      JOIN GENERAL..IT4_WMS_DOCUMENTO_ITEM B (NOLOCK) ON A.IDCONTROLE = B.IDCONTROLE
                                      JOIN BLOOMERS_LINX..LINXPEDIDOSVENDA_TRUSTED C (NOLOCK) ON C.COD_PEDIDO = REPLACE(REPLACE(A.DOCUMENTO, 'MI-VD', ''), 'MI-LJ', '') AND C.CNPJ_EMP = A.NB_DOC_REMETENTE
                                      JOIN BLOOMERS_LINX..LINXVENDEDORES_TRUSTED D (NOLOCK) ON C.COD_VENDEDOR = D.COD_VENDEDOR
                                      WHERE 
                                      A.DOCUMENTO = '{nr_pedido}'
                                      AND A.NB_DOC_REMETENTE = '{cnpj_emp}'
                                      AND A.SERIE = '{serie}'");
            }
            else if (nr_pedido.Contains("-VF"))
            {
                sql = sql.Replace("[1]", "OBS").Replace("[0]", $@"FROM GENERAL..IT4_WMS_DOCUMENTO A (NOLOCK)
                                      JOIN GENERAL..IT4_WMS_DOCUMENTO_ITEM B (NOLOCK) ON A.IDCONTROLE = B.IDCONTROLE
                                      JOIN BLOOMERS_LINX..LINXMOVIMENTO_TRUSTED C (NOLOCK) ON C.DOCUMENTO = SUBSTRING (A.DOCUMENTO, 8, LEN(A.DOCUMENTO)) AND C.CNPJ_EMP = A.NB_DOC_REMETENTE
                                      JOIN BLOOMERS_LINX..LINXVENDEDORES_TRUSTED D (NOLOCK) ON C.COD_VENDEDOR = D.COD_VENDEDOR
                                      WHERE 
                                      (C.CODIGO_ROTINA_ORIGEM = 12 OR C.CODIGO_ROTINA_ORIGEM = 16) AND
						              A.DOCUMENTO = '{nr_pedido}'
                                      AND A.NB_DOC_REMETENTE = '{cnpj_emp}'
                                      AND A.SERIE = '{serie}'");
            }
            else
            {
                sql = sql.Replace("[1]", "ANOTACAO").Replace("[0]", $@"FROM GENERAL..IT4_WMS_DOCUMENTO A (NOLOCK)
                                      JOIN GENERAL..IT4_WMS_DOCUMENTO_ITEM B (NOLOCK) ON A.IDCONTROLE = B.IDCONTROLE
                                      JOIN BLOOMERS_LINX..B2CCONSULTAPEDIDOS_TRUSTED C (NOLOCK) ON C.ORDER_ID = A.DOCUMENTO AND C.EMPRESA = A.NB_COD_REMETENTE
                                      JOIN BLOOMERS_LINX..LINXVENDEDORES_TRUSTED D (NOLOCK) ON C.COD_VENDEDOR = D.COD_VENDEDOR
                                      WHERE 
                                      A.DOCUMENTO = '{nr_pedido}'
                                      AND A.NB_DOC_REMETENTE = '{cnpj_emp}'
                                      AND A.SERIE = '{serie}'");
            }

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<PickingOrder, Company, Client, ShippingCompany, PickingProduct, PickingOrder>(sql, (pedido, empresa, cliente, transportadora, produto) =>
                    {
                        pedido.client = cliente;
                        pedido.company = empresa;
                        pedido.client = cliente;
                        pedido.shippingCompany = transportadora;
                        pedido.itens.Add(produto);
                        return pedido;
                    }, splitOn: "name_company, reason_client, cod_shippingcompany, iditem");

                    var pedidos = result.GroupBy(p => p.number).Select(g =>
                    {
                        var groupedOrder = g.First();
                        groupedOrder.itens = g.Select(p => p.itens.Single()).ToList();
                        return groupedOrder;
                    });

                    return pedidos.First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Picking] - GetUnpickedOrder - Erro ao obter pedido: {nr_pedido} na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<List<PickingOrder>?> GetUnpickedOrdersToPrint(string cnpj_emp, string serie_pedido, string data_inicial, string data_final)
        {
            throw new NotImplementedException();

            //try
            //{
            //    var result = await _conn.GetDbConnection().QueryAsync<Order, Client, ShippingCompany, Invoice, Product, Order>(sql, (pedido, cliente, transportadora, nota_fiscal, produto) =>
            //    {
            //        pedido.client = cliente;
            //        pedido.shippingCompany = transportadora;
            //        pedido.invoice = nota_fiscal;
            //        pedido.itens.Add(produto);
            //        return pedido;
            //    }, splitOn: "cod_client, cod_shippingCompany, amount_nf, cod_product");

            //    var pedidos = result.GroupBy(p => p.number).Select(g =>
            //    {
            //        var groupedOrder = g.First();
            //        groupedOrder.itens = g.Select(p => p.itens.Single()).ToList();
            //        return groupedOrder;
            //    });

            //    return pedidos.ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"MiniWms [Confere Pedido] - GetPedidosNaoConferidos - Erro ao obter pedidos na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            //}
        }

        public async Task<int> UpdateRetorno(string nr_pedido, int volumes, string listProdutos)
        {
            var sql = _pickingCommandHandler.CreateUpdateRetornoQuery(nr_pedido, volumes, listProdutos);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    return await conn.ExecuteAsync(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Confere Pedido] - UpdateReturnIT4_WMS_DOCUMENTO - Erro ao atualizar retorno do pedido: {nr_pedido} na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<int> UpdateShippingCompany(string nr_pedido, int cod_transportador)
        {
            var sql = _pickingCommandHandler.CreateUpdateShippingCompanyQuery(nr_pedido, cod_transportador);
            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    return await conn.ExecuteAsync(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Picking] - UpdateShippingCompany - Erro ao atualizar informacoes da transportadora do pedido: {nr_pedido} na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }
    }
}
