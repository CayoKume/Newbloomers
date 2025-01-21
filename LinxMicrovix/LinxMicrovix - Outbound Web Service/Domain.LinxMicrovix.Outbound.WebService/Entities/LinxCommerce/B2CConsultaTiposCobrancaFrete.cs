using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaTiposCobrancaFrete", Schema = "linx_microvix_commerce")]
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

            this.codigo_tipo_cobranca_frete =
                ConvertToInt32Validation.IsValid(codigo_tipo_cobranca_frete, "codigo_tipo_cobranca_frete", listValidations) ?
                Convert.ToInt32(codigo_tipo_cobranca_frete) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_tipo_cobranca_frete = nome_tipo_cobranca_frete;
        }
    }
}
