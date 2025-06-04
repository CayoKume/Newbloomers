using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxSangriaSuprimentos
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? usuario { get; private set; }

        public DateTime? data { get; private set; }

        public decimal? valor { get; private set; }

        public string? obs { get; private set; }

        [LengthValidation(length: 1, propertyName: "cancelado")]
        public string? cancelado { get; private set; }

        public bool? conferido { get; private set; }

        public Int64? cod_historico { get; private set; }

        [LengthValidation(length: 50, propertyName: "desc_historico")]
        public string? desc_historico { get; private set; }

        public Int32? id_sangria_suprimentos { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSangriaSuprimentos() { }

        public LinxSangriaSuprimentos(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? usuario,
            string? data,
            string? valor,
            string? obs,
            string? cancelado,
            string? conferido,
            string? cod_historico,
            string? desc_historico,
            string? id_sangria_suprimentos
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.usuario =
                ConvertToInt32Validation.IsValid(usuario, "usuario", listValidations) ?
                Convert.ToInt32(usuario) :
                0;

            this.id_sangria_suprimentos =
                ConvertToInt32Validation.IsValid(id_sangria_suprimentos, "id_sangria_suprimentos", listValidations) ?
                Convert.ToInt32(id_sangria_suprimentos) :
                0;

            this.cod_historico =
                ConvertToInt64Validation.IsValid(cod_historico, "cod_historico", listValidations) ?
                Convert.ToInt64(cod_historico) :
                0;

            this.data =
                ConvertToDateTimeValidation.IsValid(data, "data", listValidations) ?
                Convert.ToDateTime(data) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.valor =
                ConvertToDecimalValidation.IsValid(valor, "valor", listValidations) ?
                Convert.ToDecimal(valor, new CultureInfo("en-US")) :
                0;

            this.conferido =
                ConvertToBooleanValidation.IsValid(conferido, "conferido", listValidations) ?
                Convert.ToBoolean(conferido) :
                false;

            this.cnpj_emp = cnpj_emp;
            this.cancelado = cancelado;
            this.desc_historico = desc_historico;
            this.obs = obs;
        }
    }
}
