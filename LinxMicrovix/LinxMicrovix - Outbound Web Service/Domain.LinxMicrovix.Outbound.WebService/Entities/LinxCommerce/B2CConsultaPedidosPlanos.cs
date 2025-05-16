using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaPedidosPlanos
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int64? id_pedido_planos { get; private set; }

        public Int32? id_pedido { get; private set; }

        public Int32? plano_pagamento { get; private set; }

        public decimal? valor_plano { get; private set; }

        [LengthValidation(length: 20, propertyName: "nsu_sitef")]
        public string? nsu_sitef { get; private set; }

        [LengthValidation(length: 50, propertyName: "        public string? cod_autorizacao { get; private set; }\r\n")]
        public string? cod_autorizacao { get; private set; }

        public string? texto_comprovante { get; private set; }

        [LengthValidation(length: 10, propertyName: "cod_loja_sitef")]
        public string? cod_loja_sitef { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPedidosPlanos() { }

        public B2CConsultaPedidosPlanos(
            List<ValidationResult> listValidations,
            string? id_pedido_planos,
            string? id_pedido,
            string? plano_pagamento,
            string? valor_plano,
            string? nsu_sitef,
            string? cod_autorizacao,
            string? texto_comprovante,
            string? cod_loja_sitef,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_pedido_planos =
                ConvertToInt32Validation.IsValid(id_pedido_planos, "id_pedido_planos", listValidations) ?
                Convert.ToInt32(id_pedido_planos) :
                0;

            this.id_pedido =
                ConvertToInt32Validation.IsValid(id_pedido, "id_pedido", listValidations) ?
                Convert.ToInt32(id_pedido) :
                0;

            this.plano_pagamento =
                ConvertToInt32Validation.IsValid(plano_pagamento, "plano_pagamento", listValidations) ?
                Convert.ToInt32(plano_pagamento) :
                0;

            this.valor_plano =
                ConvertToDecimalValidation.IsValid(valor_plano, "valor_plano", listValidations) ?
                Convert.ToDecimal(valor_plano) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nsu_sitef = nsu_sitef;
            this.cod_autorizacao = cod_autorizacao;
            this.texto_comprovante = texto_comprovante;
            this.cod_loja_sitef = cod_loja_sitef;
            this.recordXml = recordXml;
        }
    }
}
