using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxListagemBalanco", Schema = "untreated")]
    public class LinxListagemBalanco
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_balanco { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_arquivo { get; private set; }

        [Column(TypeName = "varchar(1)")]
        public string? processado { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_ultimo_processamento { get; private set; }

        [Column(TypeName = "int")]
        public string qtde_produtos { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_itens { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
