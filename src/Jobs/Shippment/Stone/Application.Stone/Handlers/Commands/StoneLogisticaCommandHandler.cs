using Application.Stone.Interfaces.Handlers.Commands;
using Domain.Stone.Entities;
using Microsoft.Win32;

namespace Application.Stone.Handlers.Commands
{
    public class StoneLogisticaCommandHandler : IStoneLogisticaCommandHandler
    {
        public string CreateGetExistingReferenceKeysQuery()
        {
            return $@"SELECT DISTINCT
                          A.DOCUMENTO,
                          REFERENCEKEY
                      FROM
                          [GENERAL].[IT4_WMS_DOCUMENTO] A (NOLOCK)
                      JOIN
                          [GENERAL].[STONELOGISTICAORDERS] B (NOLOCK) ON REPLACE(B.REFERENCEKEY, '3294_29_', '') = A.DOCUMENTO
                      LEFT JOIN 
                          [GENERAL].[STONELOGISTICAZPLLABELS] C (NOLOCK) ON C.DOCUMENTO = A.DOCUMENTO
                      LEFT JOIN 
                          [GENERAL].[STONELOGISTICAERRORS] D (NOLOCK) ON A.DOCUMENTO = D.ORDERNUMBER
                      WHERE
                          C.DOCUMENTO IS NULL
                          AND D.ORDERNUMBER IS NULL";
        }

        public string CreateGetParametersQuery()
        {
            return $"SELECT DISTINCT email, password  FROM [general].[Parametros_StoneLogistica]";
        }

        public string CreateGetRegistersExistsQuery()
        {
            return $@"SELECT DISTINCT
                            TRIM(A.DOCUMENTO) AS NUMBER,
                            A.VOLUMES AS VOLUMES,

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
                            A.NB_CIDADE_CLIENTE AS CITY_CLIENT,
                            A.NB_UF_CLIENTE AS UF_CLIENT,
                            A.NB_CEP_CLIENTE AS ZIP_CODE_CLIENT,
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
                            (SELECT CAST(SUBSTRING(A.[XML_FATURAMENTO], CHARINDEX('<vFrete>', CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX))) + 8, 4) AS DECIMAL(14,2))) AS SHIPPING_VALUE_NF,
                            (SELECT CAST(SUBSTRING(A.[XML_FATURAMENTO], CHARINDEX('<pesoB>', CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX))) + 7, 4) AS DECIMAL(14,2))) AS WEIGHT_NF,
                            A.CHAVE_NFE AS KEY_NFE_NF,
                            CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX)) AS XML_NF,
                            CAST(A.[XML_FATURAMENTO] AS VARCHAR(MAX)) AS XML_DISTRIBUITION_NF,
                            'NF' as TYPE_NF,
                            (SELECT SUBSTRING(A.[XML_FATURAMENTO], CHARINDEX('<serie>', A.[XML_FATURAMENTO]) + 7, 1)) AS SERIE_NF,
                            (SELECT SUBSTRING(A.[XML_FATURAMENTO], CHARINDEX('<dhEmi>', A.[XML_FATURAMENTO]) + 7, 25)) AS DATE_EMISSION_NF
                      FROM 
	                      GENERAL.IT4_WMS_DOCUMENTO A (NOLOCK)
                      JOIN 
                          GENERAL.IT4_WMS_DOCUMENTO_ITEM B (NOLOCK) ON A.IDCONTROLE = B.IDCONTROLE
                      LEFT JOIN 
	                      GENERAL.STONELOGISTICAORDERSSHIPPED C (NOLOCK) ON A.DOCUMENTO = C.ORDERNUMBER
                      LEFT JOIN 
	                      GENERAL.STONELOGISTICAERRORS D (NOLOCK) ON A.DOCUMENTO = D.ORDERNUMBER
                      WHERE 
	                      A.NB_COD_TRANSPORTADORA = 97586
                      AND
                          A.CHAVE_NFE IS NOT NULL
                      AND 
	                      (A.DOCUMENTO LIKE '%-VD%' OR A.DOCUMENTO LIKE '%-VF%' OR A.DOCUMENTO LIKE '%-LJ%')
                      AND 
	                      A.DATA > CAST(GETDATE() -7 AS DATE)
                      AND 
	                      C.ORDERNUMBER IS NULL
                      AND 
                          D.ORDERNUMBER IS NULL";
        }

        public string CreateGetRegistersExistsQuery(List<Guid> registros)
        {
            string identificadores = String.Empty;
            int indice = registros.Count() / 1000;

            if (indice > 1)
            {
                for (int i = 0; i <= indice; i++)
                {
                    var top1000List = registros.Skip(i * 1000).Take(1000).ToList();

                    for (int j = 0; j < top1000List.Count(); j++)
                    {

                        if (j == top1000List.Count() - 1)
                            identificadores += $"'{top1000List[j]}'";
                        else
                            identificadores += $"'{top1000List[j]}', ";
                    }

                    return $"SELECT ORDERID, UPDATEDAT FROM [GENERAL].[STONELOGISTICAORDERS] WHERE ORDERID IN ({identificadores})";
                }
            }

            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i]}'";
                else
                    identificadores += $"'{registros[i]}', ";
            }

            return $"SELECT ORDERID, UPDATEDAT FROM [GENERAL].[STONELOGISTICAORDERS] WHERE ORDERID IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            throw new NotImplementedException();
        }

        public string CreateInsertZplsQuery(List<Zpl> zpls)
        {
            string identificadores = String.Empty;
            int indice = zpls.Count() / 1000;

            if (indice > 1)
            {
                for (int i = 0; i <= indice; i++)
                {
                    var top1000List = zpls.Skip(i * 1000).Take(1000).ToList();

                    for (int j = 0; j < top1000List.Count(); j++)
                    {

                        if (j == top1000List.Count() - 1)
                            identificadores += $"({top1000List[j].lastupdateon}, '{top1000List[j].documento}', '{top1000List[j].zpl}');";
                        else
                            identificadores += $"({top1000List[j].lastupdateon}, '{top1000List[j].documento}', '{top1000List[j].zpl}'), ";
                    }

                    return $"INSERT INTO [GENERAL].[STONELOGISTICAZPLLABELS] ([LASTUPDATEON], [DOCUMENTO], [ZPL]) VALUES {identificadores}";
                }
            }

            for (int i = 0; i < zpls.Count(); i++)
            {
                if (i == zpls.Count() - 1)
                    identificadores += $"({zpls[i].lastupdateon}, '{zpls[i].documento}', '{zpls[i].zpl}');";
                else
                    identificadores += $"({zpls[i].lastupdateon}, '{zpls[i].documento}', '{zpls[i].zpl}'), ";
            }

            return $"INSERT INTO [GENERAL].[STONELOGISTICAZPLLABELS] ([LASTUPDATEON], [DOCUMENTO], [ZPL]) VALUES {identificadores}";
        }
    }
}
