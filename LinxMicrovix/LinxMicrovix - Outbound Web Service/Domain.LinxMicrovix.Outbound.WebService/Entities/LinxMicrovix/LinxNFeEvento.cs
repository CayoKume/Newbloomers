using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxNFeEvento
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? id_nfe_evento { get; private set; }

        public Int32? id_nfe { get; private set; }

        [LengthValidation(length: 6, propertyName: "codigo_tipo")]
        public string? codigo_tipo { get; private set; }

        public string? xml { get; private set; }

        public Int64? timestamp { get; private set; }

        public DateTime? data_emissao { get; private set; }

        [LengthValidation(length: 5, propertyName: "hora_emissao")]
        public string? hora_emissao { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxNFeEvento() { }

        public LinxNFeEvento(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? id_nfe_evento,
            string? id_nfe,
            string? codigo_tipo,
            string? xml,
            string? timestamp,
            string? data_emissao,
            string? hora_emissao
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_nfe_evento =
                ConvertToInt32Validation.IsValid(id_nfe_evento, "id_nfe_evento", listValidations) ?
                Convert.ToInt32(id_nfe_evento) :
                0;

            this.id_nfe =
                ConvertToInt32Validation.IsValid(id_nfe, "id_nfe", listValidations) ?
                Convert.ToInt32(id_nfe) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.data_emissao =
                ConvertToDateTimeValidation.IsValid(data_emissao, "data_emissao", listValidations) ?
                Convert.ToDateTime(data_emissao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.hora_emissao = hora_emissao;
            this.xml = xml;
            this.codigo_tipo = codigo_tipo;
            this.cnpj_emp = cnpj_emp;
        }
    }
}
