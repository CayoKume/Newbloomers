using Dapper;
using Domain.TotalExpress.Entites;
using Domain.TotalExpress.Interfaces.Repository;
using Infrastructure.IntegrationsCore.Connections.MySQL;
using Infrastructure.IntegrationsCore.Connections.PostgreSQL;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Newtonsoft.Json;
using System.Data;

namespace Infrastructure.TotalExpress.Repository
{
    public class TotalExpressRepository : ITotalExpressRepository
    {
        private readonly ISQLServerConnection _sqlServerConnection;
        private readonly IMySQLConnection _mysqlConnection;
        private readonly IPostgreSQLConnection _postgreSQLConnection;

        public TotalExpressRepository(ISQLServerConnection sqlServerConnection) =>
            (_sqlServerConnection) = (sqlServerConnection);

        public TotalExpressRepository(IMySQLConnection mysqlConnection) =>
            (_mysqlConnection) = (mysqlConnection);

        public TotalExpressRepository(IPostgreSQLConnection postgreSQLConnection) =>
            (_postgreSQLConnection) = (postgreSQLConnection);

        public async Task<bool> GenerateRequestLog(string? orderNumber, string? request)
        {
            string? sql = $@"INSERT INTO [GENERAL].[dbo].[TOTALEXPRESSREQUESTLOG] (PEDIDO, DATAENVIO, REQUEST) 
                            VALUES (@OrderNumber, GETDATE(), @Request)";
            var parameter = new { 
                OrderNumber = orderNumber, 
                Request = request.Replace("'", "''") 
            };

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(""))
                {
                    var result = await conn.ExecuteAsync(
                        sql: sql,
                        commandType: CommandType.Text,
                        param: parameter,
                        commandTimeout: 360
                    );

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
                //throw new ExecuteCommandWithParametersException()
                //{
                //    project = "TotalExpress",
                //    method = "GenerateRequestLog",
                //    schema = "[GENERAL].[dbo].[TOTALEXPRESSREQUESTLOG]",
                //    message = "",
                //    job = "",
                //    parameter = JsonConvert.SerializeObject(parameter),
                //    command = sql,
                //    exception = ex.Message
                //};
            }
        }

        public async Task<bool> GenerateResponseLog(string? orderNumber, string? sender_id, string? response)
        {
            string? sql = @$"INSERT INTO [GENERAL].[dbo].[TOTALEXPRESSREGISTROLOG] (PEDIDO, REMETENTEID, DATAENVIO, RETORNO) 
                         VALUES (@OrderNumber, @SenderID, GETDATE(), @Return)";
            var parameter = new {
                OrderNumber = orderNumber,
                Return = response,
                SenderID = sender_id
            };

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(""))
                {
                    var result = await conn.ExecuteAsync(
                        sql: sql,
                        commandType: CommandType.Text,
                        param: parameter,
                        commandTimeout: 360
                    );

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
                //throw new ExecuteCommandWithParametersException()
                //{
                //    project = "TotalExpress",
                //    method = "GenerateResponseLog",
                //    schema = "[GENERAL].[dbo].[TOTALEXPRESSREGISTROLOG]",
                //    job = "",
                //    message = "",
                //    parameter = JsonConvert.SerializeObject(parameter),
                //    command = sql,
                //    exception = ex.Message
                //};
            }
        }

        public async Task<Order> GetInvoicedOrder(string? orderNumber)
        {
            string? sql = $@"SELECT DISTINCT 
                            TRIM(A.DOCUMENTO) AS NUMBER,
                            A.VOLUMES AS VOLUMES,
                            A.NB_CFOP_PEDIDO AS CFOP,
                            A.NB_METODO_TRANSPORTADORA AS SHIPPMENT_METHOD,

                            B.CODIGO_BARRA AS COD_PRODUCT,
                            B.NB_SKU_PRODUTO AS SKU_PRODUCT,
                            B.DESCRICAO AS DESCRIPTION_PRODUCT,
                            B.CODIGO_BARRA AS COD_EAN_PRODUCT,
                            B.QTDE AS QUANTITY_PRODUCT,
                            B.NB_VALOR_UNITARIO_PRODUTO AS UNITARY_VALUE_PRODUCT,
                            B.NB_VALOR_TOTAL_PRODUTO AS AMOUNT_PRODUCT,
                            B.NB_VALOR_FRETE_PRODUTO AS SHIPPING_VALUE_PRODUCT,

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
                            A.NB_CIDADE AS CITY_CLIENT,
                            A.NB_ESTADO AS UF_CLIENT,
                            A.NB_CEP AS ZIP_CODE_CLIENT,
                            A.NB_FONE_CLIENTE AS FONE_CLIENT,
                            A.NB_INSCRICAO_ESTADUAL_CLIENTE AS STATE_REGISTRATION_CLIENT,
                            A.NB_INSCRICAO_MUNICIPAL_CLIENTE AS MUNICIPAL_REGISTRATION_CLIENT,

                            A.NB_TRANSPORTADORA AS COD_SHIPPINGCOMPANY,
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

                            CASE
                                WHEN A.NB_DOC_REMETENTE = '38367316000865' THEN '38367316000199' --ENVIA PEDIDOS PARA TOTAL DA MISHA - VOLO COMO MISHA - MATRIZ
                                ELSE A.NB_DOC_REMETENTE
                            END AS DOC_COMPANY,

                            A.NB_EMAIL_REMETENTE AS EMAIL_COMPANY,
                            A.NB_ENDERECO_REMETENTE AS ADDRESS_COMPANY,
                            A.NB_NUMERO_RUA_REMETENTE AS STREET_NUMBER_COMPANY,
                            A.NB_COMPLEMENTO_END_REMETENTE AS COMPLEMENT_ADDRESS_COMPANY,
                            A.NB_BAIRRO_REMETENTE AS NEIGHBORHOOD_COMPANY,
                            A.NB_CIDADE_REMETENTE AS CITY_COMPANY,
                            A.NB_UF_REMETENTE AS UF_COMPANY,
                            A.NB_CEP_REMETENTE AS ZIP_CODE_COMPANY,
                            A.NB_FONE_REMETENTE AS FONE_COMPANY,
                            A.NB_INSCRICAO_ESTADUAL_REMETENTE AS STATE_REGISTRATION_COMPANY,

                            A.NF_SAIDA AS NUMBER_NF,
                            A.NB_VALOR_PEDIDO AS AMOUNT_NF,
                            (SELECT CAST(SUBstring? (A.[XML_FATURAMENTO], CHARINDEX('<vFrete>', CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX))) + 8, 4) AS DECIMAL(14,2))) AS SHIPPING_VALUE_NF,
                            (SELECT CAST(SUBstring? (A.[XML_FATURAMENTO], CHARINDEX('<pesoB>', CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX))) + 7, 4) AS DECIMAL(14,2))) AS WEIGHT_NF,
                            A.CHAVE_NFE AS KEY_NFE_NF,
                            CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX)) AS XML_NF,
                            CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX)) AS XML_DISTRIBUITION_NF,
                            'NF' as TYPE_NF,
                            (SELECT SUBstring? (A.[XML_FATURAMENTO], CHARINDEX('<serie>', A.[XML_FATURAMENTO]) + 7, 1)) AS SERIE_NF,
                            (SELECT SUBstring? (A.[XML_FATURAMENTO], CHARINDEX('<dhEmi>', A.[XML_FATURAMENTO]) + 7, 25)) AS DATE_EMISSION_NF

                            FROM [GENERAL].[dbo].[IT4_WMS_DOCUMENTO] A (NOLOCK)
                            JOIN [GENERAL].[dbo].[IT4_WMS_DOCUMENTO_ITEM] B (NOLOCK) ON A.IDCONTROLE = B.IDCONTROLE
                            LEFT JOIN GENERAL..TOTALEXPRESSREGISTROLOG C (NOLOCK) ON A.DOCUMENTO = C.PEDIDO

                            WHERE
                            A.DOCUMENTO IN ('{orderNumber}')
                            AND A.SERIE != 'MX-'
                            AND A.ORIGEM = 'P'
                            AND A.CHAVE_NFE IS NOT NULL 
                            AND A.XML_FATURAMENTO IS NOT NULL";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(""))
                {
                    var result = await conn.QueryAsync<Order, Product, Client, ShippingCompany, Company, Invoice, Order>(sql, (order, product, client, shippingCompany, company, invoice) =>
                    {
                        order.itens.Add(product);
                        order.client = client;
                        order.shippingCompany = shippingCompany;
                        order.company = company;
                        order.invoice = invoice;
                        return order;
                    }, splitOn: "COD_PRODUCT, COD_CLIENT, COD_SHIPPINGCOMPANY, COD_COMPANY, NUMBER_NF", commandTimeout: 360);

                    var order = result.GroupBy(p => p.number).Select(g =>
                    {
                        var groupedOrder = g.FirstOrDefault();
                        groupedOrder.itens = g.Select(p => p.itens.Single()).ToList();
                        return groupedOrder;
                    });

                    return order.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
                //throw new ObjectNotFoundExcpetion()
                //{
                //    project = "TotalExpress",
                //    method = "GetInvoicedOrder",
                //    schema = "[GENERAL].[dbo].[IT4_WMS_DOCUMENTO]",
                //    job = "",
                //    message = "",
                //    command = sql,
                //    exception = ex.Message
                //};
            }
        }

        public async Task<List<Order>> GetInvoicedOrders()
        {
            string? sql = @"SELECT DISTINCT 
                            TRIM(A.DOCUMENTO) AS NUMBER,
                            A.VOLUMES AS VOLUMES,
                            A.NB_CFOP_PEDIDO AS CFOP,

                            B.CODIGO_BARRA AS COD_PRODUCT,
                            B.NB_SKU_PRODUTO AS SKU_PRODUCT,
                            B.DESCRICAO AS DESCRIPTION_PRODUCT,
                            B.CODIGO_BARRA AS COD_EAN_PRODUCT,
                            B.QTDE AS QUANTITY_PRODUCT,
                            B.NB_VALOR_UNITARIO_PRODUTO AS UNITARY_VALUE_PRODUCT,
                            B.NB_VALOR_TOTAL_PRODUTO AS AMOUNT_PRODUCT,
                            B.NB_VALOR_FRETE_PRODUTO AS SHIPPING_VALUE_PRODUCT,

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
                            A.NB_CIDADE AS CITY_CLIENT,
                            A.NB_ESTADO AS UF_CLIENT,
                            A.NB_CEP AS ZIP_CODE_CLIENT,
                            A.NB_FONE_CLIENTE AS FONE_CLIENT,
                            A.NB_INSCRICAO_ESTADUAL_CLIENTE AS STATE_REGISTRATION_CLIENT,
                            A.NB_INSCRICAO_MUNICIPAL_CLIENTE AS MUNICIPAL_REGISTRATION_CLIENT,

                            A.NB_TRANSPORTADORA AS COD_SHIPPINGCOMPANY,
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

                            CASE
                                WHEN A.NB_DOC_REMETENTE = '38367316000865' THEN '38367316000199' --ENVIA PEDIDOS PARA TOTAL DA MISHA - VOLO COMO MISHA - MATRIZ
                                ELSE A.NB_DOC_REMETENTE
                            END AS DOC_COMPANY,

                            A.NB_EMAIL_REMETENTE AS EMAIL_COMPANY,
                            A.NB_ENDERECO_REMETENTE AS ADDRESS_COMPANY,
                            A.NB_NUMERO_RUA_REMETENTE AS STREET_NUMBER_COMPANY,
                            A.NB_COMPLEMENTO_END_REMETENTE AS COMPLEMENT_ADDRESS_COMPANY,
                            A.NB_BAIRRO_REMETENTE AS NEIGHBORHOOD_COMPANY,
                            A.NB_CIDADE_REMETENTE AS CITY_COMPANY,
                            A.NB_UF_REMETENTE AS UF_COMPANY,
                            A.NB_CEP_REMETENTE AS ZIP_CODE_COMPANY,
                            A.NB_FONE_REMETENTE AS FONE_COMPANY,
                            A.NB_INSCRICAO_ESTADUAL_REMETENTE AS STATE_REGISTRATION_COMPANY,

                            A.NF_SAIDA AS NUMBER_NF,
                            A.NB_VALOR_PEDIDO AS AMOUNT_NF,
                            (SELECT CAST(SUBstring? (A.[XML_FATURAMENTO], CHARINDEX('<vFrete>', CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX))) + 8, 4) AS DECIMAL(14,2))) AS SHIPPING_VALUE_NF,
                            (SELECT CAST(SUBstring? (A.[XML_FATURAMENTO], CHARINDEX('<pesoB>', CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX))) + 7, 4) AS DECIMAL(14,2))) AS WEIGHT_NF,
                            A.CHAVE_NFE AS KEY_NFE_NF,
                            CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX)) AS XML_NF,
                            CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX)) AS XML_DISTRIBUITION_NF,
                            'NF' as TYPE_NF,
                            (SELECT SUBstring? (A.[XML_FATURAMENTO], CHARINDEX('<serie>', A.[XML_FATURAMENTO]) + 7, 1)) AS SERIE_NF,
                            (SELECT SUBstring? (A.[XML_FATURAMENTO], CHARINDEX('<dhEmi>', A.[XML_FATURAMENTO]) + 7, 25)) AS DATE_EMISSION_NF

                            FROM [GENERAL].[dbo].[IT4_WMS_DOCUMENTO] A (NOLOCK)
                            JOIN [GENERAL].[dbo].[IT4_WMS_DOCUMENTO_ITEM] B (NOLOCK) ON A.IDCONTROLE = B.IDCONTROLE
                            LEFT JOIN GENERAL..TOTALEXPRESSREGISTROLOG C (NOLOCK) ON A.DOCUMENTO = C.PEDIDO
                            WHERE
                            A.SERIE != 'MX-'
							AND A.ORIGEM = 'P'
                            AND A.CHAVE_NFE IS NOT NULL 
                            AND A.XML_FATURAMENTO IS NOT NULL 
                            AND A.NB_TRANSPORTADORA = '7601'
                            AND A.DATA > GETDATE() - 15
                            AND A.VOLUMES IS NOT NULL
							AND (C.PEDIDO IS NULL OR SUBstring?(C.retorno, 3, 7) <> 'retorno') 
							AND NOT EXISTS (SELECT 0 FROM GENERAL..TotalExpressRegistroLog TER (NOLOCK) WHERE TER.pedido = C.pedido AND SUBstring?(TER.retorno, 3, 7) = 'retorno')";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(""))
                {
                    var result = await conn.QueryAsync<Order, Product, Client, ShippingCompany, Company, Invoice, Order>(sql, (order, product, client, shippingCompany, company, invoice) =>
                    {
                        order.itens.Add(product);
                        order.client = client;
                        order.shippingCompany = shippingCompany;
                        order.company = company;
                        order.invoice = invoice;
                        return order;
                    }, splitOn: "COD_PRODUCT, COD_CLIENT, COD_SHIPPINGCOMPANY, COD_COMPANY, NUMBER_NF", commandTimeout: 360);

                    return result.GroupBy(p => p.number).Select(g =>
                    {
                        var groupedOrder = g.FirstOrDefault();
                        groupedOrder.itens = g.Select(p => p.itens.Single()).ToList();
                        return groupedOrder;
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
                //throw new ObjectNotFoundExcpetion()
                //{
                //    project = "TotalExpress",
                //    method = "GetInvoicedOrders",
                //    job = "",
                //    message = "",
                //    schema = "[GENERAL].[dbo].[IT4_WMS_DOCUMENTO]",
                //    command = sql,
                //    exception = ex.Message
                //};
            }
        }

        public async Task<Parameters> GetParameters(string? docCompany, string? method)
        {
            string? sql = $@"SELECT DISTINCT
                            REMETENTE_ID AS SENDER_ID,
                            SERVICO_TIPO AS SERVICE_TYPE
                            FROM
                            [GENERAL].[dbo].[PARAMETROS_TOTALEXPRESS]
                            WHERE
                            CNPJ_EMP = '{docCompany}' AND
                            METODO = '{method}'";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(""))
                {
                    return await conn.QueryFirstOrDefaultAsync<Parameters>(sql);
                }
            }
            catch (Exception ex)
            {
                throw;
                //throw new ObjectNotFoundExcpetion()
                //{
                //    project = "TotalExpress",
                //    method = "GetParameters",
                //    job = "",
                //    message = "",
                //    schema = "[GENERAL].[dbo].[PARAMETROS_TOTALEXPRESS]",
                //    command = sql,
                //    exception = ex.Message
                //};
            }
        }

        public async Task<IEnumerable<Parameters>> GetSenderIds()
        {
            string? sql = $@"SELECT DISTINCT
                            REMETENTE_ID AS SENDER_ID
                            FROM
                            [GENERAL].[dbo].[PARAMETROS_TOTALEXPRESS]";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(""))
                {
                    return await conn.QueryAsync<Parameters>(sql);
                }
            }
            catch (Exception ex)
            {
                throw;
                //throw new ObjectNotFoundExcpetion()
                //{
                //    project = "TotalExpress",
                //    method = "GetSenderIds",
                //    schema = "[GENERAL].[dbo].[PARAMETROS_TOTALEXPRESS]",
                //    message = "",
                //    job = "",
                //    command = sql,
                //    exception = ex.Message
                //};
            }
        }

        public async Task<bool> UpdateDeliveryDates(string? deliveryMadeDate, string? collectionDate, string? deliveryForecastDate, string? lastStatusDate, string? lastStatusDescription, string? orderNumber)
        {
            string? sql = @$"UPDATE [GENERAL].[dbo].[IT4_WMS_DOCUMENTO] SET 
                            NB_DESCRICAO_ULTIMO_STATUS = '{lastStatusDescription}',
                            NB_DATA_ULTIMO_STATUS = '{lastStatusDate}',
                            NB_DATA_COLETA = convert(datetime, '{collectionDate}'),
                            NB_PREVISAO_REAL_ENTREGA = convert(datetime, '{deliveryForecastDate}'),
                            NB_DATA_ENTREGA_REALIZADA = convert(datetime, '{deliveryMadeDate}')
                            WHERE LTRIM(RTRIM(Documento)) = '{orderNumber}' 
                            AND NB_TRANSPORTADORA = '7601'
                            AND NB_DATA_ULTIMO_STATUS != '{lastStatusDate}'
                            AND NB_DESCRICAO_ULTIMO_STATUS != '{lastStatusDescription}'
                            AND NB_DATA_COLETA != '{collectionDate}'
                            AND NB_PREVISAO_REAL_ENTREGA != '{deliveryForecastDate}';";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(""))
                {
                    var result = await conn.ExecuteAsync(
                        sql: sql,
                        commandType: CommandType.Text,
                        commandTimeout: 360
                    );

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
                //throw new ObjectNotFoundExcpetion()
                //{
                //    project = "TotalExpress",
                //    method = "UpdateDeliveryDates",
                //    schema = "[GENERAL].[dbo].[IT4_WMS_DOCUMENTO]",
                //    job = "",
                //    message = "",
                //    command = sql,
                //    exception = ex.Message
                //};
            }
        }
    }
}
