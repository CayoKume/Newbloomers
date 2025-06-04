using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxProdutosFornec", Schema = "untreated")]
    public class LinxProdutosFornec
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_prod_forn { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_fornecedor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? custo { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? moeda { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? unidade_compra { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? fator_conversao_compra { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? codauxiliar { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_embalagem { get; private set; }

        [Column(TypeName = "int")]
        public string? prazo_entrega_padrao { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto2 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto3 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? ipi1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? diferencial_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? despesas1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? acrescimo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_custo_substituicao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? frete1 { get; private set; }

        [Column(TypeName = "varchar(1)")]
        public string? fornecedor_principal { get; private set; }

        [Column(TypeName = "varchar(1)")]
        public string? excluido { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
