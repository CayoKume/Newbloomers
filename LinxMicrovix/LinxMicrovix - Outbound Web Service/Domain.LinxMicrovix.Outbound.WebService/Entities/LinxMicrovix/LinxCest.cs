using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxCest", Schema = "linx_microvix_erp")]
    public class LinxCest
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_cest { get; private set; }

        [Column(TypeName = "varchar(700)")]
        [LengthValidation(length: 700, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "cest")]
        public string? cest { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_segmento_mercadoria_bem { get; private set; }

        [Column(TypeName = "bit")]
        public bool? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxCest() { }

        public LinxCest(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_cest,
            string? descricao,
            string? cest,
            string? id_segmento_mercadoria_bem,
            string? ativo,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_cest =
                ConvertToInt32Validation.IsValid(id_cest, "id_cest", listValidations) ?
                Convert.ToInt32(id_cest) :
                0;

            this.id_segmento_mercadoria_bem =
                ConvertToInt32Validation.IsValid(id_segmento_mercadoria_bem, "id_segmento_mercadoria_bem", listValidations) ?
                Convert.ToInt32(id_segmento_mercadoria_bem) :
                0;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
            this.cest = cest;
        }
    }
}
