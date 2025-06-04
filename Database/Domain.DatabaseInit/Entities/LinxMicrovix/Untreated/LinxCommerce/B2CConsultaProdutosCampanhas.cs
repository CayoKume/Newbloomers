using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaProdutosCampanhas", Schema = "untreated")]
    public class B2CConsultaProdutosCampanhas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? codigo_campanha { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_campanha { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? vigencia_inicio { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? vigencia_fim { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? observacao { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
