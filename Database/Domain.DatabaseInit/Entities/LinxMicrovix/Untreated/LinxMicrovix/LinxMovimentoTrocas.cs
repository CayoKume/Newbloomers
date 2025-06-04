using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMovimentoTrocas", Schema = "untreated")]
    public class LinxMovimentoTrocas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? num_vale { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_vale { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? motivo { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? doc_origem { get; private set; }

        [Column(TypeName = "char(10)")]
        public string? serie_origem { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? doc_venda { get; private set; }

        [Column(TypeName = "char(10)")]
        public string? serie_venda { get; private set; }

        [Column(TypeName = "bit")]
        public string? excluido { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "bit")]
        public string? desfazimento { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? vale_cod_cliente { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? vale_codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? id_vale_ordem_servico_externa { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? doc_venda_origem { get; private set; }

        [Column(TypeName = "char(10)")]
        public string? serie_venda_origem { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_cliente { get; private set; }
    }
}
