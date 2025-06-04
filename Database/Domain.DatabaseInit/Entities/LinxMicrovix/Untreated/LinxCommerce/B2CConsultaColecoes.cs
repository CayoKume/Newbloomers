using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaColecoes", Schema = "untreated")]
    public class B2CConsultaColecoes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? codigo_colecao { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? nome_colecao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? marcas { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
