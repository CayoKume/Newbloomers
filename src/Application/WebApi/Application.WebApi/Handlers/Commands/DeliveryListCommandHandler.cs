using Application.WebApi.Interfaces.Handlers.Commands;
using Domain.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Handlers.Commands
{
    public class DeliveryListCommandHandler : IDeliveryListCommandHandler
    {
        public string CreateGetDeliveryListQuery(string identificador)
        {
            return $@"SELECT DISTINCT
                      A.[uniqueidentifier],
                      A.[doc_company],
                      A.[name],
                      A.[carrier],
                      A.[printedAt],
                      A.[colletedAt]

                      FROM azure.newbloomers.[webapplication].[DeliveryLists] A (NOLOCK)
                      WHERE
                      A.uniqueidentifier = '{identificador}'";
        }

        public string CreateGetDeliveryListsQuery(string cnpj_emp, string data_inicial, string data_final)
        {
            return $@"SELECT DISTINCT
                      A.[uniqueidentifier],
                      A.[doc_company],
                      A.[name],
                      A.[carrier],
                      A.[printedAt],
                      A.[colletedAt]

                      FROM azure.newbloomers.[webapplication].[DeliveryLists] A (NOLOCK)
                      WHERE
                      A.doc_company = '{cnpj_emp}' 
                      AND A.colletedAt IS NULL
                      AND A.printedAt >= '{data_inicial.Trim()} 00:00:00'
                      AND A.printedAt <= '{data_final.Trim()} 23:59:59'";
        }

        public string CreateGetOrderShippedQuery(string nr_pedido, string serie, string cnpj_emp, string transportadora)
        {
            return $@"SELECT DISTINCT
                      TRIM(A.DOCUMENTO) AS NUMBER,
                      A.VOLUMES AS VOLUMES,
                                                          
                      A.NB_CODIGO_CLIENTE AS COD_CLIENT,
                      A.NB_RAZAO_CLIENTE AS REASON_CLIENT,
                      A.NB_DOC_CLIENTE AS DOC_CLIENT,
                      A.NB_ENDERECO_CLIENTE AS ADDRESS_CLIENT,
                      A.NB_NUMERO_RUA_CLIENTE AS STREET_NUMBER_CLIENT,
                      A.NB_COMPLEMENTO_END_CLIENTE AS COMPLEMENT_ADDRESS_CLIENT,
                      A.NB_BAIRRO_CLIENTE AS NEIGHBORHOOD_CLIENT,
                      A.NB_CIDADE AS CITY_CLIENT,
                      A.NB_ESTADO AS UF_CLIENT,
                      TRIM(REPLACE(A.NB_CEP, '-', '')) AS ZIP_CODE_CLIENT,
                      A.NB_FONE_CLIENTE AS FONE_CLIENT,
                      
                      A.NB_TRANSPORTADORA AS COD_SHIPPINGCOMPANY,
                      A.NB_RAZAO_TRANSPORTADORA AS REASON_SHIPPINGCOMPANY,

                      A.NF_SAIDA AS NUMBER_NF,
                      A.NB_VALOR_PEDIDO AS AMOUNT_NF,

                      A.NB_DOC_REMETENTE AS DOC_COMPANY

                      FROM GENERAL..IT4_WMS_DOCUMENTO A (NOLOCK)
                      WHERE
                      A.SERIE = '{serie}'
                      AND A.NB_DOC_REMETENTE = '{cnpj_emp}' 
					  AND A.DOCUMENTO = '{nr_pedido}'
                      AND A.CHAVE_NFE IS NOT NULL
                      AND A.XML_FATURAMENTO IS NOT NULL
                      AND A.NF_SAIDA IS NOT NULL
                      AND A.NB_TRANSPORTADORA = '{transportadora}'";
        }

        public string CreateGetOrdersShippedQuery(string cod_transportadora, string cnpj_emp, string serie_pedido, string data_inicial, string data_final)
        {
            var sql = @"SELECT DISTINCT
                        TRIM(A.DOCUMENTO) AS NUMBER,
                        A.VOLUMES AS VOLUMES,

						A.NB_CODIGO_CLIENTE AS COD_CLIENT,
                        A.NB_RAZAO_CLIENTE AS REASON_CLIENT,
                        A.NB_DOC_CLIENTE AS DOC_CLIENT,
                        A.NB_ENDERECO_CLIENTE AS ADDRESS_CLIENT,
                        A.NB_NUMERO_RUA_CLIENTE AS STREET_NUMBER_CLIENT,
                        A.NB_COMPLEMENTO_END_CLIENTE AS COMPLEMENT_ADDRESS_CLIENT,
                        A.NB_BAIRRO_CLIENTE AS NEIGHBORHOOD_CLIENT,
                        A.NB_CIDADE AS CITY_CLIENT,
                        A.NB_ESTADO AS UF_CLIENT,
                        TRIM(REPLACE(A.NB_CEP, '-', '')) AS ZIP_CODE_CLIENT,
                        A.NB_FONE_CLIENTE AS FONE_CLIENT,

                        A.NB_TRANSPORTADORA AS COD_SHIPPINGCOMPANY,
                        A.NB_RAZAO_TRANSPORTADORA AS REASON_SHIPPINGCOMPANY,

                        A.NF_SAIDA AS NUMBER_NF,
                        A.NB_VALOR_PEDIDO AS AMOUNT_NF,

                        A.NB_DOC_REMETENTE AS DOC_COMPANY

                        [0]";

            if (cod_transportadora == "7601")
            {
                return sql.Replace("[0]", $@"FROM GENERAL..IT4_WMS_DOCUMENTO A (NOLOCK)
                                            JOIN GENERAL..TOTALEXPRESSREGISTROLOG B (NOLOCK) ON A.DOCUMENTO = B.PEDIDO
                                            WHERE
                                            A.SERIE = '{serie_pedido}'
                                            AND A.NB_DOC_REMETENTE = '{cnpj_emp}'
                                            AND A.CHAVE_NFE IS NOT NULL
                                            AND A.XML_FATURAMENTO IS NOT NULL
                                            AND A.NF_SAIDA IS NOT NULL
                                            AND A.NB_TRANSPORTADORA = '{cod_transportadora}'
                                            AND B.DATAENVIO >= CONVERT(DATE, '{data_inicial.Trim()}')
                                            AND B.DATAENVIO <= CONCAT (CONVERT(DATE, '{data_final.Trim()}'),' 23:59:59')");
            }

            return sql.Replace("[0]", $@"FROM GENERAL..IT4_WMS_DOCUMENTO A (NOLOCK)
                                        WHERE
                                        A.SERIE = '{serie_pedido}'
                                        AND A.NB_DOC_REMETENTE = '{cnpj_emp}'
                                        AND A.CHAVE_NFE IS NOT NULL
                                        AND A.XML_FATURAMENTO IS NOT NULL
                                        AND A.NF_SAIDA IS NOT NULL
                                        AND A.NB_TRANSPORTADORA = '{cod_transportadora}'
                                        AND A.RETORNO > '{data_inicial}'
                                        AND A.RETORNO < '{data_final}'");
        }

        public string CreateInsertPickedsDatesQuery(Guid guid, string deliveryListName, string carrier, IEnumerable<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
