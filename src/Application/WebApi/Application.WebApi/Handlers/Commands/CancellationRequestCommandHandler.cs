using Application.WebApi.Interfaces.Handlers.Commands;
using Domain.Wms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Handlers.Commands
{
    public class CancellationRequestCommandHandler : ICancellationRequestCommandHandler
    {
        public string CreateCancellationRequestQuery(CancellationRequestOrder order)
        {
            var stringItens = string.Empty;

            foreach (var item in order.itens)
            {
                stringItens += $@"(@ID_CANCELAMENTO_PEDIDO, '{order.number}', {item.cod_product}, '{item.description_product}', {item.quantity_product}, {item.picked_quantity_product}, {item.unitary_value_product}, {item.amount_product})";
            }

            return $@"BEGIN TRANSACTION;

                        BEGIN TRY
                            INSERT INTO GENERAL..TB_NB_CANCELAMENTO_PEDIDOS (DATA_REGISTRO, VENDEDORA, MOTIVO_REGISTRO, PEDIDO, OBS_REGISTRO)
                            VALUES (GETDATE(), '{order.requester}', {order.reason}, '{order.number}', '{order.obs}');
                             
                            DECLARE @ID_CANCELAMENTO_PEDIDO BIGINT;
                            SET @ID_CANCELAMENTO_PEDIDO = SCOPE_IDENTITY();
                             
                            INSERT INTO GENERAL..TB_NB_CANCELAMENTO_PEDIDOS_ITENS (ID_CANCELAMENTO_PEDIDO, PEDIDO, COD_PRODUTO, DESCRICAO, QTDE, QTDERETORNO, VALOR_UNITARIO_PRODUTO, VALOR_TOTAL_PRODUTO)
                            VALUES 
                            [0];
                             
                            COMMIT TRANSACTION;
                        END TRY
                        BEGIN CATCH
                            ROLLBACK TRANSACTION;
                        END CATCH;"
                        .Replace("[0]", stringItens);
        }

        public string CreateGetOrderToCancelQuery(string number, string serie, string doc_company)
        {
            return $@"SELECT 
                      DOCUMENTO AS NUMBER, 
                      CODIGO_BARRA AS COD_PRODUCT, 
                      DESCRICAO AS DESCRIPTION_PRODUCT, 
                      QTDE AS QUANTITY_PRODUCT, 
                      QTDERETORNO AS PICKED_QUANTITY_PRODUCT, 
                      NB_SKU_PRODUTO AS SKU_PRODUCT,
                      NB_VALOR_UNITARIO_PRODUTO AS UNITARY_VALUE_PRODUCT,
                      NB_VALOR_TOTAL_PRODUTO AS AMOUNT_PRODUCT,
                      NB_VALOR_FRETE_PRODUTO AS SHIPPING_VALUE_PRODUCT

                      FROM GENERAL..IT4_WMS_DOCUMENTO A (NOLOCK)
                      JOIN GENERAL..IT4_WMS_DOCUMENTO_ITEM B (NOLOCK) ON A.IDCONTROLE = B.IDCONTROLE
                      WHERE
                      DOCUMENTO IN ('{number}')
                      AND SERIE = '{serie}'
                      AND NB_DOC_REMETENTE = '{doc_company}'";
        }

        public string CreateGetReasonsQuery()
        {
            return $@"SELECT ID_MOTIVO AS [KEY], DESCRICAO_MOTIVO AS [VALUE] FROM GENERAL..TB_NB_CANCELAMENTO_PEDIDOS_MOTIVOS";
        }
    }
}
