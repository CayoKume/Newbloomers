using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosPromocao
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int64? codigo_promocao { get; private set; }

        public Int32? empresa { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public decimal? preco { get; private set; }

        public DateTime? data_inicio { get; private set; }

        public DateTime? data_termino { get; private set; }

        public DateTime? data_cadastro { get; private set; }

        [LengthValidation(length: 1, propertyName: "ativa")]
        public string? ativa { get; private set; }

        public Int32? codigo_campanha { get; private set; }

        public Int32? promocao_opcional { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 20, propertyName: "referencia")]
        public string? referencia { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosPromocao() { }

        public B2CConsultaProdutosPromocao(
            List<ValidationResult> listValidations,
            string? codigo_promocao,
            string? empresa,
            string? codigoproduto,
            string? preco,
            string? data_inicio,
            string? data_termino,
            string? data_cadastro,
            string? ativa,
            string? codigo_campanha,
            string? promocao_opcional,
            string? timestamp,
            string? referencia,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_promocao =
                ConvertToInt32Validation.IsValid(codigo_promocao, "codigo_promocao", listValidations) ?
                Convert.ToInt32(codigo_promocao) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.preco =
                ConvertToDecimalValidation.IsValid(preco, "preco", listValidations) ?
                Convert.ToDecimal(preco, new CultureInfo("en-US")) :
                0;

            this.data_inicio =
                ConvertToDateTimeValidation.IsValid(data_inicio, "data_inicio", listValidations) ?
                Convert.ToDateTime(data_inicio) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_termino =
                ConvertToDateTimeValidation.IsValid(data_termino, "data_termino", listValidations) ?
                Convert.ToDateTime(data_termino) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_cadastro =
                ConvertToDateTimeValidation.IsValid(data_cadastro, "data_cadastro", listValidations) ?
                Convert.ToDateTime(data_cadastro) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.codigo_campanha =
                ConvertToInt32Validation.IsValid(codigo_campanha, "codigo_campanha", listValidations) ?
                Convert.ToInt32(codigo_campanha) :
                0;

            this.promocao_opcional =
                ConvertToInt32Validation.IsValid(promocao_opcional, "promocao_opcional", listValidations) ?
                Convert.ToInt32(promocao_opcional) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.ativa = ativa;
            this.referencia = referencia;
            this.recordXml = recordXml;
        }
    }
}
