using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxB2CPedidosStatus", Schema = "untreated")]
    public class LinxB2CPedidosStatus
    {
        [Column(TypeName = "datetime")]
        public string lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id { get; private set; }

        [Column(TypeName = "int")]
        public string? id_status { get; private set; }

        [Column(TypeName = "int")]
        public string? id_pedido { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_hora { get; private set; }

        [Column(TypeName = "varchar(80)")]
        public string? anotacao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
