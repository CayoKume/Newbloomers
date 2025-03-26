using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxNfse", Schema = "linx_microvix_erp")]
    public class LinxNfse
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_nfse { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? documento { get; private set; }

        [LengthValidation(length: 50, propertyName: "codigo_verificacao")]
        public string? codigo_verificacao { get; private set; }

        public Int32? id_nfse_situacao { get; private set; }

        public Guid? identificador { get; private set; }

        public DateTime? dt_insert { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxNfse() { }

        public LinxNfse(
            List<ValidationResult> listValidations,
            string? id_nfse,
            string? portal,
            string? documento,
            string? codigo_verificacao,
            string? id_nfse_situacao,
            string? identificador,
            string? dt_insert,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.documento =
                ConvertToInt32Validation.IsValid(documento, "documento", listValidations) ?
                Convert.ToInt32(documento) :
                0;

            this.id_nfse =
                ConvertToInt32Validation.IsValid(id_nfse, "id_nfse", listValidations) ?
                Convert.ToInt32(id_nfse) :
                0;

            this.id_nfse_situacao =
                ConvertToInt32Validation.IsValid(id_nfse_situacao, "id_nfse_situacao", listValidations) ?
                Convert.ToInt32(id_nfse_situacao) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.dt_insert =
               ConvertToDateTimeValidation.IsValid(dt_insert, "dt_insert", listValidations) ?
               Convert.ToDateTime(dt_insert) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigo_verificacao = codigo_verificacao;
        }
    }
}
