using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaPlanos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? plano { get; private set; }
        public string? nome_plano { get; private set; }
        public Int32? forma_pagamento { get; private set; }
        public Int32? qtde_parcelas { get; private set; }
        public decimal? valor_minimo_parcela { get; private set; }
        public decimal? indice { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? desativado { get; private set; }
        public string? tipo_plano { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPlanos() { }

        public B2CConsultaPlanos(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaPlanos record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);

            this.plano = CustomConvertersExtensions.ConvertToInt32Validation(record.plano);
            this.forma_pagamento = CustomConvertersExtensions.ConvertToInt32Validation(record.forma_pagamento);
            this.qtde_parcelas = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_parcelas);
            this.valor_minimo_parcela = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_minimo_parcela);
            this.indice = CustomConvertersExtensions.ConvertToDecimalValidation(record.indice);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nome_plano = record.nome_plano;
            this.desativado = record.desativado;
            this.tipo_plano = record.tipo_plano;
            this.recordXml = recordXml;
        }
    }
}
