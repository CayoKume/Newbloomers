using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxMovimentoOrigemDevolucoes", Schema = "linx_microvix_erp")]
    public class LinxMovimentoOrigemDevolucoes
    {
        public DateTime? lastupdateon { get; private set; }

        public Guid? identificador { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? nota_origem { get; private set; }

        public Int32? ecf_origem { get; private set; }

        public DateTime? data_origem { get; private set; }

        [LengthValidation(length: 10, propertyName: "serie_origem")]
        public string? serie_origem { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? portal { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoOrigemDevolucoes() { }

        public LinxMovimentoOrigemDevolucoes(
            List<ValidationResult> listValidations,
            string? identificador,
            string? cnpj_emp,
            string? nota_origem,
            string? ecf_origem,
            string? data_origem,
            string? serie_origem,
            string? empresa,
            string? portal,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.nota_origem =
                ConvertToInt32Validation.IsValid(nota_origem, "nota_origem", listValidations) ?
                Convert.ToInt32(nota_origem) :
                0;

            this.ecf_origem =
                ConvertToInt32Validation.IsValid(ecf_origem, "ecf_origem", listValidations) ?
                Convert.ToInt32(ecf_origem) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.data_origem =
               ConvertToDateTimeValidation.IsValid(data_origem, "data_origem", listValidations) ?
               Convert.ToDateTime(data_origem) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.cnpj_emp = cnpj_emp;
            this.serie_origem = serie_origem;
        }
    }
}
