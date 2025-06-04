using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxECF", Schema = "untreated")]
    public class LinxECF
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_ecf { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? ecf { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? numeroserie { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? indice_sangria { get; private set; }

        [Column(TypeName = "int")]
        public string? modelo { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? nome { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? indice_suprimento { get; private set; }

        [Column(TypeName = "int")]
        public string? ativo { get; private set; }

        [Column(TypeName = "varchar(53)")]
        public string? indice_sinal { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? indice_antecipacao { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? indice_cartao_credito { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? empresa_ecf { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
