using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaVendedores
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? cod_vendedor { get; private set; }
        public string? nome_vendedor { get; private set; }
        public decimal? comissao_produtos { get; private set; }
        public decimal? comissao_servicos { get; private set; }
        public string? tipo { get; private set; }
        public Int32? ativo { get; private set; }
        public Int32? comissionado { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaVendedores() { }

        public B2CConsultaVendedores(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaVendedores record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.cod_vendedor = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_vendedor);
            this.comissao_produtos = CustomConvertersExtensions.ConvertToDecimalValidation(record.comissao_produtos);
            this.comissao_servicos = CustomConvertersExtensions.ConvertToDecimalValidation(record.comissao_servicos);
            this.ativo = CustomConvertersExtensions.ConvertToInt32Validation(record.ativo);
            this.comissionado = CustomConvertersExtensions.ConvertToInt32Validation(record.comissionado);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nome_vendedor = record.nome_vendedor;
            this.tipo = record.tipo;
            this.recordXml = recordXml;
        }
    }
}
