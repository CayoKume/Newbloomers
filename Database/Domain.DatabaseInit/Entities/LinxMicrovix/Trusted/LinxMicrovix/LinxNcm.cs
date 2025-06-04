using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxNcm", Schema = "linx_microvix_erp")]
    public class LinxNcm
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codigo { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_genero { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_ncm { get; private set; }

        [Column(TypeName = "int")]
        public string? timestamp { get; private set; }
    }
}
