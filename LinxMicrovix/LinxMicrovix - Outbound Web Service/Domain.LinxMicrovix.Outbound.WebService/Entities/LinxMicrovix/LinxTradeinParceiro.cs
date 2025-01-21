using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxTradeinParceiro", Schema = "linx_microvix_erp")]
    public class LinxTradeinParceiro
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_tradein_parceiro { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "nome_parceiro")]
        public string? nome_parceiro { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxTradeinParceiro() { }

        public LinxTradeinParceiro(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_tradein_parceiro,
            string? nome_parceiro,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_tradein_parceiro =
                ConvertToInt32Validation.IsValid(id_tradein_parceiro, "id_tradein_parceiro", listValidations) ?
                Convert.ToInt32(id_tradein_parceiro) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_parceiro = nome_parceiro;
        }
    }
}
