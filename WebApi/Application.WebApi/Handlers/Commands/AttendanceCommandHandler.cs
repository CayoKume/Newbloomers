using Application.WebApi.Interfaces.Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Handlers.Commands
{
    public class AttendanceCommandHandler : IAttendanceCommandHandler
    {
        public string CreateGetOrdersToContactQuery(string serie, string doc_company)
        {
            return $@"SELECT DISTINCT
                      B.PEDIDO AS NUMBER,
                      IIF(B.DATA_CONTATO IS NULL, 'CONTATAR', 'CONTATADO') AS CONTACTED,

                      A.NB_CODIGO_CLIENTE AS COD_CLIENT,
                      A.NB_RAZAO_CLIENTE AS REASON_CLIENT,
                      A.NB_NOME_CLIENTE AS NAME_CLIENT,
                      A.NB_DOC_CLIENTE AS DOC_CLIENT,
                      A.NB_EMAIL_CLIENTE AS EMAIL_CLIENT,
                      A.NB_ENDERECO_CLIENTE AS ADDRESS_CLIENT,
                      A.NB_NUMERO_RUA_CLIENTE AS STREET_NUMBER_CLIENT,
                      A.NB_COMPLEMENTO_END_CLIENTE AS COMPLEMENT_ADDRESS_CLIENT,
                      A.NB_BAIRRO_CLIENTE AS NEIGHBORHOOD_CLIENT,
                      A.NB_CIDADE AS CITY_CLIENT,
                      A.NB_ESTADO AS UF_CLIENT,
                      TRIM(REPLACE(A.NB_CEP, '-', '')) AS ZIP_CODE_CLIENT,
                      A.NB_FONE_CLIENTE AS FONE_CLIENT,
                      A.NB_INSCRICAO_ESTADUAL_CLIENTE AS STATE_REGISTRATION_CLIENT,
                      A.NB_INSCRICAO_MUNICIPAL_CLIENTE AS MUNICIPAL_REGISTRATION_CLIENT,
                      
                      C.COD_PRODUTO AS COD_PRODUCT,
                      C.DESCRICAO AS DESCRIPTION_PRODUCT,
                      C.QTDE AS QUANTITY_PRODUCT,
                      C.QTDERETORNO AS PICKED_QUANTITY,
                      C.VALOR_UNITARIO_PRODUTO AS UNITARY_VALUE_PRODUCT,
                      C.VALOR_TOTAL_PRODUTO AS AMOUNT_PRODUCT
                      
                      FROM GENERAL..IT4_WMS_DOCUMENTO A (NOLOCK) 
                      JOIN GENERAL..TB_NB_CANCELAMENTO_PEDIDOS B (NOLOCK) ON A.DOCUMENTO = B.PEDIDO
                      JOIN GENERAL..TB_NB_CANCELAMENTO_PEDIDOS_ITENS C (NOLOCK) ON B.ID_CANCELAMENTO_PEDIDO = C.ID_CANCELAMENTO_PEDIDO

                      WHERE
                      B.SAC IS NULL
                      AND B.DATA_CONTATO IS NULL
                      AND A.SERIE = '{serie}'
                      AND A.NB_DOC_REMETENTE = '{doc_company}'";
        }

        public string CreateUpdateDateContactedQuery(string number, string atendente, string obs)
        {
            return $@"UPDATE [GENERAL].[dbo].[TB_NB_CANCELAMENTO_PEDIDOS] SET SAC = '{atendente}', DATA_CONTATO = GETDATE(), OBS_SAC = '{obs}' WHERE PEDIDO = '{number}'";
        }
    }
}
