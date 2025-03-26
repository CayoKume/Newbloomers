using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxLojas", Schema = "untreated")]
    public class LinxLojas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_emp { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? razao_emp { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? inscricao_emp { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? endereco_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? num_emp { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? complement_emp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? bairro_emp { get; private set; }

        [Column(TypeName = "char(9)")]
        public string? cep_emp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? cidade_emp { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? estado_emp { get; private set; }

        [Column(TypeName = "varchar(70)")]
        public string? fone_emp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? email_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_ibge_municipio { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_criacao_emp { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_criacao_portal { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? sistema_tributacao { get; private set; }

        [Column(TypeName = "int")]
        public string? regime_tributario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? area_empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? sigla_empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? id_classe_fiscal { get; private set; }

        [Column(TypeName = "bit")]
        public string? centro_distribuicao { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? inscricao_municipal_emp { get; private set; }

        [Column(TypeName = "varchar(7)")]
        public string? cnae_emp { get; private set; }

        [Column(TypeName = "varchar(6)")]
        public string? cod_cliente_linx { get; private set; }

        [Column(TypeName = "int")]
        public string? tabela_preco_preferencial { get; private set; }
    }
}
