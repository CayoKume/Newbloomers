using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxB2CStatus
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_status { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? descricao_status { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public LinxB2CStatus() { }

        public LinxB2CStatus(
            string? id_status,
            string? descricao_status,
            string? timestamp,
            string? portal
        )
        {
            
        }
    }
}
