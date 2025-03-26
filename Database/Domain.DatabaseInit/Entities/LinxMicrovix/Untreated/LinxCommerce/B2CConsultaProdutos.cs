using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaProdutos", Schema = "untreated")]
    public class B2CConsultaProdutos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? codauxiliar1 { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? descricao_basica { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? nome_produto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? peso_liquido { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_setor { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_linha { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_marca { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_colecao { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_espessura { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_grade1 { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_grade2 { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? unidade { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_classificacao { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? dt_cadastro { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? observacao { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_fornecedor { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? dt_update { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? altura_para_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? largura_para_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? comprimento_para_frete { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? peso_bruto { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(8000)")]
        public string? descricao_completa_commerce { get; private set; }

        [Column(TypeName = "tinyint")]
        public string? canais_ecommerce_publicados { get; private set; }

        [Column(TypeName = "date")]
        public string? inicio_publicacao_produto { get; private set; }

        [Column(TypeName = "date")]
        public string? fim_publicacao_produto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_integracao_oms { get; private set; }
    }
}
