using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxMetodos", Schema = "linx_microvix_erp")]
    public class LinxMetodos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? methodID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? Retorno { get; set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMetodos() { }

        public LinxMetodos(
            string? Retorno
        )
        {
            lastupdateon = DateTime.Now;
            this.Retorno = Retorno;
        }
    }
}
