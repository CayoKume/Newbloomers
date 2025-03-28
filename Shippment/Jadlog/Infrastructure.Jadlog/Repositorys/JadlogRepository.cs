using Dapper;
using Domain.IntegrationsCore.Entities.Bases;
using Domain.Jadlog.Entities;
using Domain.Jadlog.Interfaces.Repositorys;
using Infrastructure.IntegrationsCore.Connections.SQLServer;

namespace Infrastructure.Jadlog.Repositorys
{
    public class JadlogRepository : IJadlogRepository
    {
        private readonly ISQLServerConnection _conn;

        public JadlogRepository(ISQLServerConnection conn) =>
            _conn = conn;

        public Task InsertResponse(string pedido, string request, InsertResponse response)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetInvoicedOrder(string orderNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetInvoicedOrders()
        {
            var sql = $@"SELECT DISTINCT 
                         TRIM(A.DOCUMENTO) AS NUMBER,
                         A.VOLUMES AS VOLUMES,
                         A.NB_CFOP_PEDIDO AS CFOP,
                         CASE
                             WHEN A.CLIENTE_OU_FORNECEDOR IN (SELECT COD_CLIENTE FROM LINX_MICROVIX_ERP.LINXCLIENTESFORNEC (NOLOCK) WHERE (RAZAO_CLIENTE LIKE '%MNR%')  AND TIPO_CLIENTE = 'J') THEN 'B2B' --B2B MISHA
                             WHEN A.CLIENTE_OU_FORNECEDOR IN (SELECT COD_CLIENTE FROM LINX_MICROVIX_ERP.LINXCLIENTESFORNEC (NOLOCK) WHERE (RAZAO_CLIENTE LIKE '%NEWFIT%')  AND TIPO_CLIENTE = 'J') THEN 'B2B' --B2B OPEN ERA
                             WHEN A.NB_COD_REMETENTE IN (SELECT EMPRESA FROM LINX_MICROVIX_ERP.LINXLOJAS (NOLOCK) WHERE EMPRESA NOT IN (0, 1, 5, 6, 10)) THEN 'SHIP FROM STORE' --SHIP FROM STORE OPEN ERA E MISHA (EXCLUI MISHA ECOMMERCE, OPEN ECOMMERCE, MARGAUX ECOMMERCE E NEWBLOOMERS)
                             ELSE 'B2C'
                         END AS TIPO_SERVICO,
                         
                         B.CODIGO_BARRA AS COD_PRODUCT,
                         B.NB_SKU_PRODUTO AS SKU_PRODUCT,
                         B.DESCRICAO AS DESCRIPTION_PRODUCT,
                         B.CODIGO_BARRA AS COD_EAN_PRODUCT,
                         B.QTDE AS QUANTITY_PRODUCT,
                         B.NB_VALOR_UNITARIO_PRODUTO AS UNITARY_VALUE_PRODUCT,
                         B.NB_VALOR_TOTAL_PRODUTO AS AMOUNT_PRODUCT,
                         B.NB_VALOR_FRETE_PRODUTO AS SHIPPING_VALUE_PRODUCT,
                         B.NB_PESO_BRUTO AS WEIGHT_PRODUCT,
                         
                         A.NB_CODIGO_CLIENTE AS COD_CLIENT,
                         A.NB_RAZAO_CLIENTE AS REASON_CLIENT,
                         A.NB_NOME_CLIENTE AS NAME_CLIENT,
                         A.NB_DOC_CLIENTE AS DOC_CLIENT,
                         A.NB_EMAIL_CLIENTE AS EMAIL_CLIENT,
                         A.NB_ENDERECO_CLIENTE AS ADDRESS_CLIENT,
                         CASE
                             WHEN A.NB_NUMERO_RUA_CLIENTE = '' THEN 'SVN'
                             ELSE A.NB_NUMERO_RUA_CLIENTE
                         END AS STREET_NUMBER_CLIENT,
                         A.NB_COMPLEMENTO_END_CLIENTE AS COMPLEMENT_ADDRESS_CLIENT,
                         A.NB_BAIRRO_CLIENTE AS NEIGHBORHOOD_CLIENT,
                         A.NB_CIDADE_CLIENTE AS CITY_CLIENT,
                         A.NB_UF_CLIENTE AS UF_CLIENT,
                         REPLACE(TRIM(A.NB_CEP_CLIENTE), '-', '') AS ZIP_CODE_CLIENT,
                         A.NB_FONE_CLIENTE AS FONE_CLIENT,
                         A.NB_INSCRICAO_ESTADUAL_CLIENTE AS STATE_REGISTRATION_CLIENT,
                         A.NB_INSCRICAO_MUNICIPAL_CLIENTE AS MUNICIPAL_REGISTRATION_CLIENT,
                         
                         A.NB_COD_TRANSPORTADORA AS COD_SHIPPINGCOMPANY,
                         A.NB_METODO_TRANSPORTADORA AS METODO_SHIPPINGCOMPANY,
                         A.NB_RAZAO_TRANSPORTADORA AS REASON_SHIPPINGCOMPANY,
                         A.NB_NOME_TRANSPORTADORA AS NAME_SHIPPINGCOMPANY,
                         A.NB_DOC_TRANSPORTADORA AS DOC_SHIPPINGCOMPANY,
                         A.NB_EMAIL_TRANSPORTADORA AS EMAIL_SHIPPINGCOMPANY,
                         A.NB_ENDERECO_TRANSPORTADORA AS ADDRESS_SHIPPINGCOMPANY,
                         A.NB_NUMERO_RUA_TRANSPORTADORA AS STREET_NUMBER_SHIPPINGCOMPANY,
                         A.NB_COMPLEMENTO_END_TRANSPORTADORA AS COMPLEMENT_ADDRESS_SHIPPINGCOMPANY,
                         A.NB_BAIRRO_TRANSPORTADORA AS NEIGHBORHOOD_SHIPPINGCOMPANY,
                         A.NB_CIDADE_TRANSPORTADORA AS CITY_SHIPPINGCOMPANY,
                         A.NB_UF_TRANSPORTADORA AS UF_SHIPPINGCOMPANY,
                         A.NB_CEP_TRANSPORTADORA AS ZIP_CODE_SHIPPINGCOMPANY,
                         A.NB_FONE_TRANSPORTADORA AS FONE_SHIPPINGCOMPANY,
                         A.NB_INSCRICAO_ESTADUAL_TRANSPORTADORA AS STATE_REGISTRATION_SHIPPINGCOMPANY,
                         
                         A.NB_COD_REMETENTE AS COD_COMPANY,
                         A.NB_RAZAO_REMETENTE AS REASON_COMPANY,
                         A.NB_NOME_REMETENTE AS NAME_COMPANY,
                         A.NB_DOC_REMETENTE AS DOC_COMPANY,
                         A.NB_EMAIL_REMETENTE AS EMAIL_COMPANY,
                         A.NB_ENDERECO_REMETENTE AS ADDRESS_COMPANY,
                         A.NB_NUMERO_RUA_REMETENTE AS STREET_NUMBER_COMPANY,
                         A.NB_COMPLEMENTO_END_REMETENTE AS COMPLEMENT_ADDRESS_COMPANY,
                         A.NB_BAIRRO_REMETENTE AS NEIGHBORHOOD_COMPANY,
                         A.NB_CIDADE_REMETENTE AS CITY_COMPANY,
                         A.NB_UF_REMETENTE AS UF_COMPANY,
                         REPLACE(TRIM(A.NB_CEP_REMETENTE), '-', '') AS ZIP_CODE_COMPANY,
                         A.NB_FONE_REMETENTE AS FONE_COMPANY,
                         A.NB_INSCRICAO_ESTADUAL_REMETENTE AS STATE_REGISTRATION_COMPANY,
                         
                         D.EMPRESA AS COD_COMPANY,
                         D.RAZAO_EMP AS REASON_COMPANY,
                         D.NOME_EMP AS NAME_COMPANY,
                         D.CNPJ_EMP AS DOC_COMPANY,
                         D.EMAIL_EMP AS EMAIL_COMPANY,
                         D.ENDERECO_EMP AS ADDRESS_COMPANY,
                         D.NUM_EMP AS STREET_NUMBER_COMPANY,
                         D.COMPLEMENT_EMP AS COMPLEMENT_ADDRESS_COMPANY,
                         D.BAIRRO_EMP AS NEIGHBORHOOD_COMPANY,
                         D.CIDADE_EMP AS CITY_COMPANY,
                         D.ESTADO_EMP AS UF_COMPANY,
                         REPLACE(TRIM(D.CEP_EMP), '-', '') AS ZIP_CODE_COMPANY,
                         D.FONE_EMP AS FONE_COMPANY,
                         D.INSCRICAO_EMP AS STATE_REGISTRATION_COMPANY,
                         
                         A.NF_SAIDA AS NUMBER_NF,
                         A.NB_VALOR_PEDIDO AS AMOUNT_NF,
                         (SELECT CAST(SUBSTRING (A.[XML_FATURAMENTO], CHARINDEX('<vFrete>', CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX))) + 8, 4) AS DECIMAL(14,2))) AS SHIPPING_VALUE_NF,
                         (SELECT CAST(SUBSTRING (A.[XML_FATURAMENTO], CHARINDEX('<pesoB>', CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX))) + 7, 4) AS DECIMAL(14,2))) AS WEIGHT_NF,
                         A.CHAVE_NFE AS KEY_NFE_NF,
                         CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX)) AS XML_NF,
                         CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX)) AS XML_DISTRIBUITION_NF,
                         'NF' as TYPE_NF,
                         (SELECT SUBSTRING (A.[XML_FATURAMENTO], CHARINDEX('<serie>', A.[XML_FATURAMENTO]) + 7, 1)) AS SERIE_NF,
                         (SELECT SUBSTRING (A.[XML_FATURAMENTO], CHARINDEX('<dhEmi>', A.[XML_FATURAMENTO]) + 7, 25)) AS DATE_EMISSION_NF
                         
                         FROM [GENERAL].[IT4_WMS_DOCUMENTO] A (NOLOCK)
                         JOIN [GENERAL].[IT4_WMS_DOCUMENTO_ITEM] B (NOLOCK) ON A.IDCONTROLE = B.IDCONTROLE
                         LEFT JOIN [GENERAL].[JADLOGPEDIDOS] C (NOLOCK) ON A.DOCUMENTO = C.PEDIDO
	                     JOIN [GENERAL].[JADLOGERROS] E (NOLOCK) ON C.PEDIDO = E.PEDIDO
                         JOIN [LINX_MICROVIX_ERP].[LINXLOJAS] D (NOLOCK) ON D.CNPJ_EMP = IIF(A.SERIE = 'MI-', '38367316000199', '42538267000187')
                         WHERE
                         --A.DOCUMENTO IN ('')
                         A.SERIE != 'MX-'
	                     AND A.ORIGEM = 'P'
                         AND A.CHAVE_NFE IS NOT NULL 
                         AND A.XML_FATURAMENTO IS NOT NULL 
                         AND A.NB_COD_TRANSPORTADORA = '101988'
                         AND A.DATA > GETDATE() - 15
                         AND A.VOLUMES IS NOT NULL
                         AND (
			                     (
				                     C.PEDIDO IS NULL OR
				                     (E.DESCRICAO NOT LIKE '%já foi enviado. Solicitacao de coleta:%' AND C.STATUS = 'Erro ao inserir solicitacao.')
			                     )
                         )
                         AND B.IDITEM = 1";

            try
            {
                using (var conn = _conn.GetDbConnection())
                {
                    var result = await conn.QueryAsync<Order, Product, ClientBase, ShippingCompanyBase, CompanyBase, CompanyBase, InvoiceBase, Order>(sql, (order, product, client, shippingCompany, company, tomador, invoice) =>
                    {
                        order.itens.Add(product);
                        order.client = client;
                        order.shippingCompany = shippingCompany;
                        order.company = company;
                        order.tomador = tomador;
                        order.invoice = invoice;
                        return order;
                    }, splitOn: "COD_PRODUCT, COD_CLIENT, COD_SHIPPINGCOMPANY, COD_COMPANY, COD_COMPANY, NUMBER_NF", commandTimeout: 360);

                    var orders = result.GroupBy(p => p.number).Select(g =>
                    {
                        var groupedOrder = g.First();
                        groupedOrder.itens = g.Select(p => p.itens.Single()).ToList();
                        return groupedOrder;
                    });

                    return orders.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(@$"Jadlog - GetInvoicedOrders - Erro ao obter pedidos da tabela GENERAL..IT4_WMS_DOCUMENTO - {ex.Message}");
            }
        }

        public async Task<IEnumerable<Parameters>> GetParameters()
        {
            var sql = $@"SELECT DISTINCT
                         A.CODIGO_CLIENTE AS COD_CLIENT,
                         A.CNPJ_EMP AS DOC_COMPANY,
                         A.MODALIDADE AS MODALITY,
                         A.TOKEN AS TOKEN,
                         A.PRODUTO AS PRODUCT,
                         LEFT(A.CONTA, 6) AS ACCOUNT
                         FROM GENERAL.PARAMETROS_JADLOG A (NOLOCK)";

            try
            {
                using (var conn = _conn.GetDbConnection())
                {
                    return await conn.QueryAsync<Parameters>(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(@$"Jadlog - GetToken - Erro ao obter token da tabela GENERAL..PARAMETROS_JADLOG - {ex.Message}");
            }
        }

        public async Task<Parameters> GetParameters(string doc_company, string tipo_servico)
        {
            var sql = $@"SELECT DISTINCT
                         A.CODIGO_CLIENTE AS COD_CLIENT,
                         A.CNPJ_EMP AS DOC_COMPANY,
                         A.MODALIDADE AS MODALITY,
                         A.TOKEN AS TOKEN,
                         LEFT(A.CONTA, 6) AS ACCOUNT
                         FROM GENERAL.PARAMETROS_JADLOG A (NOLOCK)
                         WHERE 
                         A.CNPJ_EMP = '{doc_company}'
                         AND A.PRODUTO = '{tipo_servico}'";

            try
            {
                using (var conn = _conn.GetDbConnection())
                {
                    return await conn.QueryFirstAsync<Parameters>(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(@$"Jadlog - GetToken - Erro ao obter token da tabela GENERAL..PARAMETROS_JADLOG - {ex.Message}");
            }
        }

        public async Task<IEnumerable<ShipmentId>> GetShipmentIds()
        {
            var sql = $@"SELECT DISTINCT TOP 100
                         A.SHIPMENTID AS SHIPMENT_ID,

						 -- PROVISORIO ATÉ A LIBERAÇÃO DA IT4_WMS_DOCUMENTO
						 D.CNPJ_EMP AS DOC_COMPANY,
						 CASE
							WHEN C.COD_CLIENTE_ERP IN (SELECT COD_CLIENTE FROM LINX_MICROVIX_ERP.LINXCLIENTESFORNEC (NOLOCK) WHERE (RAZAO_CLIENTE LIKE '%MNR%')  AND TIPO_CLIENTE = 'J') THEN 'B2B' --B2B MISHA
							WHEN C.COD_CLIENTE_ERP IN (SELECT COD_CLIENTE FROM LINX_MICROVIX_ERP.LINXCLIENTESFORNEC (NOLOCK) WHERE (RAZAO_CLIENTE LIKE '%NEWFIT%')  AND TIPO_CLIENTE = 'J') THEN 'B2B' --B2B OPEN ERA
							WHEN C.EMPRESA IN (SELECT EMPRESA FROM LINX_MICROVIX_ERP.LINXLOJAS (NOLOCK) WHERE EMPRESA NOT IN (0, 1, 5, 6, 10)) THEN 'SHIP FROM STORE' --SHIP FROM STORE OPEN ERA E MISHA (EXCLUI MISHA ECOMMERCE, OPEN ECOMMERCE, MARGAUX ECOMMERCE E NEWBLOOMERS)
							ELSE 'B2C'
						 END AS PRODUCT

                         --C.NB_DOC_REMETENTE AS DOC_COMPANY,
						 --CASE
							--WHEN C.CLIENTE_OU_FORNECEDOR IN (SELECT COD_CLIENTE FROM LINX_MICROVIX_ERP.LINXCLIENTESFORNEC (NOLOCK) WHERE (RAZAO_CLIENTE LIKE '%MNR%')  AND TIPO_CLIENTE = 'J') THEN 'B2B' --B2B MISHA
							--WHEN C.CLIENTE_OU_FORNECEDOR IN (SELECT COD_CLIENTE FROM LINX_MICROVIX_ERP.LINXCLIENTESFORNEC (NOLOCK) WHERE (RAZAO_CLIENTE LIKE '%NEWFIT%')  AND TIPO_CLIENTE = 'J') THEN 'B2B' --B2B OPEN ERA
							--WHEN C.NB_COD_REMETENTE IN (SELECT EMPRESA FROM LINX_MICROVIX_ERP.LINXLOJAS (NOLOCK) WHERE EMPRESA NOT IN (0, 1, 5, 6, 10)) THEN 'SHIP FROM STORE' --SHIP FROM STORE OPEN ERA E MISHA (EXCLUI MISHA ECOMMERCE, OPEN ECOMMERCE, MARGAUX ECOMMERCE E NEWBLOOMERS)
							--ELSE 'B2C'
						 --END AS PRODUCT

                         FROM GENERAL.JADLOGPEDIDOS A (NOLOCK)
                         LEFT JOIN GENERAL.JADLOGTRACKING B (NOLOCK) ON A.SHIPMENTID = B.SHIPMENTID
						 
						 -- PROVISORIO ATÉ A LIBERAÇÃO DA IT4_WMS_DOCUMENTO
						 JOIN LINX_MICROVIX_COMMERCE.B2CCONSULTAPEDIDOS C (NOLOCK) ON A.PEDIDO = C.ORDER_ID
						 JOIN LINX_MICROVIX_ERP.LINXLOJAS D (NOLOCK) ON C.EMPRESA = D.EMPRESA

						 --JOIN GENERAL.IT4_WMS_DOCUMENTO C (NOLOCK) ON A.PEDIDO = C.DOCUMENTO

                         WHERE A.SHIPMENTID != ''
                         AND B.SHIPMENTID IS NULL";

            try
            {
                using (var conn = _conn.GetDbConnection())
                {
                    return await conn.QueryAsync<ShipmentId>(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(@$"Jadlog - GetShipmentIds - Erro ao obter shipments IDs da tabela GENERAL.JADLOGPEDIDOS - {ex.Message}");
            }
        }
    }
}
