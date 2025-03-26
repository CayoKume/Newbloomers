using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaProdutosCamposAdicionaisNomes", Schema = "untreated")]
    public class B2CConsultaProdutosCamposAdicionaisNomes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_campo { get; private set; }

        [Column(TypeName = "tinyint")]
        public string? ordem { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? legenda { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
