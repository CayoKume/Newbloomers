using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPlanosBandeiras
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? plano { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 30, propertyName: "bandeira")]
        public string? bandeira { get; private set; }

        [LengthValidation(length: 100, propertyName: "tipo_bandeira")]
        public string? tipo_bandeira { get; private set; }

        public Int32? adquirente { get; private set; }

        [LengthValidation(length: 60, propertyName: "nome_adquirente")]
        public string? nome_adquirente { get; private set; }

        [LengthValidation(length: 10, propertyName: "codigo_bandeira_sitef")]
        public string? codigo_bandeira_sitef { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPlanosBandeiras() { }

        public LinxPlanosBandeiras(
            List<ValidationResult> listValidations,
            string? portal,
            string? plano,
            string? bandeira,
            string? tipo_bandeira,
            string? adquirente,
            string? nome_adquirente,
            string? codigo_bandeira_sitef
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.plano =
                ConvertToInt32Validation.IsValid(plano, "plano", listValidations) ?
                Convert.ToInt32(plano) :
                0;

            this.adquirente =
                ConvertToInt32Validation.IsValid(adquirente, "adquirente", listValidations) ?
                Convert.ToInt32(adquirente) :
                0;

            this.bandeira = bandeira;
            this.tipo_bandeira = tipo_bandeira;
            this.nome_adquirente = nome_adquirente;
            this.codigo_bandeira_sitef = codigo_bandeira_sitef;
        }
    }
}
