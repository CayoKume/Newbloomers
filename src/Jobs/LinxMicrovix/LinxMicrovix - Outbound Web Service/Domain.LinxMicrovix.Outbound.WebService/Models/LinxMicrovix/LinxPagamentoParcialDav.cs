
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPagamentoParcialDav
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_pagamento_parcial_tmp { get; private set; }
        public Int32? id_vendas_pos { get; private set; }
        public decimal? valor { get; private set; }
        public decimal? ajuste_valor_desc_acresc_plano { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? plano { get; private set; }
        public string? forma_pgto { get; private set; }
        public Int32? id_bandeira { get; private set; }
        public Int32? qtde_parcelas { get; private set; }
        public string? credito_debito { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPagamentoParcialDav() { }

        public LinxPagamentoParcialDav(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPagamentoParcialDav record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_vendas_pos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vendas_pos);
            this.id_pagamento_parcial_tmp = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pagamento_parcial_tmp);
            this.plano = CustomConvertersExtensions.ConvertToInt32Validation(record.plano);
            this.id_bandeira = CustomConvertersExtensions.ConvertToInt32Validation(record.id_bandeira);
            this.qtde_parcelas = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_parcelas);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor);
            this.ajuste_valor_desc_acresc_plano = CustomConvertersExtensions.ConvertToDecimalValidation(record.ajuste_valor_desc_acresc_plano);
            this.forma_pgto = record.forma_pgto;
            this.credito_debito = record.credito_debito;
        }
    }
}
