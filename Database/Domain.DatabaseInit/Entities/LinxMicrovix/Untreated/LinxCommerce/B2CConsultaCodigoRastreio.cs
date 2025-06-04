using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaCodigoRastreio", Schema = "untreated")]
    public class B2CConsultaCodigoRastreio
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_pedido { get; private set; }

        [Column(TypeName = "int")]
        public string? documento { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codigo_rastreio { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? sequencia_volume { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
