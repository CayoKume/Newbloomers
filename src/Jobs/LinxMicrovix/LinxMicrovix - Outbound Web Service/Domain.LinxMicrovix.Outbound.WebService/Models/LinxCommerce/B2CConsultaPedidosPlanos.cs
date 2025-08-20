
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaPedidosPlanos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? id_pedido_planos { get; private set; }
        public Int32? id_pedido { get; private set; }
        public Int32? plano_pagamento { get; private set; }
        public decimal? valor_plano { get; private set; }
        public string? nsu_sitef { get; private set; }
        public string? cod_autorizacao { get; private set; }
        public string? texto_comprovante { get; private set; }
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
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaPedidosPlanos record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_pedido_planos = CustomConvertersExtensions.ConvertToInt64Validation(record.id_pedido_planos);
            this.id_pedido = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pedido);
            this.plano_pagamento = CustomConvertersExtensions.ConvertToInt32Validation(record.plano_pagamento);
            this.valor_plano = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_plano);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nsu_sitef = record.nsu_sitef;
            this.cod_autorizacao = record.cod_autorizacao;
            this.texto_comprovante = record.texto_comprovante;
            this.cod_loja_sitef = record.cod_loja_sitef;
            this.recordXml = recordXml;
        }
    }
}
