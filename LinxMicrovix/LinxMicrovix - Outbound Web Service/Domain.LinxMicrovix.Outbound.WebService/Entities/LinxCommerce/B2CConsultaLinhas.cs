using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaLinhas", Schema = "linx_microvix_commerce")]
    public class B2CConsultaLinhas
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? codigo_linha { get; private set; }

        [LengthValidation(length: 30, propertyName: "nome_linha")]
        public string? nome_linha { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 250, propertyName: "setores")]
        public string? setores { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaLinhas() { }

        public B2CConsultaLinhas(
            List<ValidationResult> listValidations,
            string? codigo_linha,
            string? nome_linha,
            string? timestamp,
            string? setores,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_linha =
                ConvertToInt32Validation.IsValid(codigo_linha, "codigo_linha", listValidations) ?
                Convert.ToInt32(codigo_linha) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_linha = nome_linha;
            this.setores = setores;
            this.recordXml = recordXml;
        }
    }
}
