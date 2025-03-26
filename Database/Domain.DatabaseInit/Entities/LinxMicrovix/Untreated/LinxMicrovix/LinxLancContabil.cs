using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxLancContabil", Schema = "untreated")]
    public class LinxLancContabil
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? cod_lanc { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? centro_custo { get; private set; }

        [Column(TypeName = "varchar(150)")]
        public string? ind_conta { get; private set; }

        [Column(TypeName = "bigint")]
        public string? cod_conta { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_conta { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_conta { get; private set; }

        [Column(TypeName = "varchar(1)")]
        public string? cred_deb { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_lanc { get; private set; }

        [Column(TypeName = "varchar(500)")]
        public string? compl_conta { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "bigint")]
        public string? cod_historico { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? desc_historico { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_compensacao { get; private set; }

        [Column(TypeName = "int")]
        public string? fatura_origem { get; private set; }

        [Column(TypeName = "varchar(1)")]
        public string? efetivado { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "bigint")]
        public string? id_lanc { get; private set; }

        [Column(TypeName = "varchar(1)")]
        public string? cancelado { get; private set; }
    }
}
