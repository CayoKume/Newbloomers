using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxFidelidade", Schema = "untreated")]
    public class LinxFidelidade
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }


        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_fidelidade_parceiro_log { get; private set; }

        [Column(TypeName = "int")]
        public string? data_transacao { get; private set; }

        [Column(TypeName = "int")]
        public string? operacao { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? aprovado_barramento { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_monetario { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? numero_cartao { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_movimento { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
