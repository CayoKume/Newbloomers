using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFrete
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_tipo_cobranca_frete { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "nome_tipo_cobranca_frete")]
        public string? nome_tipo_cobranca_frete { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaTiposCobrancaFrete() { }

        public B2CConsultaTiposCobrancaFrete(
            List<ValidationResult> listValidations,
            string? codigo_tipo_cobranca_frete,
            string? nome_tipo_cobranca_frete,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.nome_tipo_cobranca_frete = nome_tipo_cobranca_frete;

            this.codigo_tipo_cobranca_frete =
                String.IsNullOrEmpty(codigo_tipo_cobranca_frete) ? 0
                : Convert.ToInt32(codigo_tipo_cobranca_frete);

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
