using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaVendedores
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? cod_vendedor { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_vendedor")]
        public string? nome_vendedor { get; private set; }

        public decimal? comissao_produtos { get; private set; }

        public decimal? comissao_servicos { get; private set; }

        [LengthValidation(length: 1, propertyName: "tipo")]
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
            List<ValidationResult> listValidations,
            string? cod_vendedor,
            string? nome_vendedor,
            string? comissao_produtos,
            string? comissao_servicos,
            string? tipo,
            string? ativo,
            string? comissionado,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_vendedor =
                ConvertToInt32Validation.IsValid(cod_vendedor, "cod_vendedor", listValidations) ?
                Convert.ToInt32(cod_vendedor) :
                0;

            this.comissao_produtos =
                ConvertToDecimalValidation.IsValid(comissao_produtos, "comissao_produtos", listValidations) ?
                Convert.ToDecimal(comissao_produtos, new CultureInfo("en-US")) :
                0;

            this.comissao_servicos =
                ConvertToDecimalValidation.IsValid(comissao_servicos, "comissao_servicos", listValidations) ?
                Convert.ToDecimal(comissao_servicos, new CultureInfo("en-US")) :
                0;

            this.ativo =
                ConvertToInt32Validation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToInt32(ativo) :
                0;

            this.comissionado =
                ConvertToInt32Validation.IsValid(comissionado, "comissionado", listValidations) ?
                Convert.ToInt32(comissionado) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_vendedor = nome_vendedor;
            this.tipo = tipo;
            this.recordXml = recordXml;
        }
    }
}
