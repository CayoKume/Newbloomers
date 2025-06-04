using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaStatus", Schema = "untreated")]
    public class B2CConsultaStatus
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_status { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string? descricao_status { get; set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; set; }

        [Column(TypeName = "int")]
        public string? portal { get; set; }
    }
}
