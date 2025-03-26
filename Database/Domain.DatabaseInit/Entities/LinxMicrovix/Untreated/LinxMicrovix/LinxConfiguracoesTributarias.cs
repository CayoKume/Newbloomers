using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxConfiguracoesTributarias", Schema = "untreated")]
    public class LinxConfiguracoesTributarias
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? id_config_tributaria { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? desc_config_tributaria { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? sigla_config_tributaria { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativa { get; private set; }

        [Column(TypeName = "varchar(2)")]
        public string? uf { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? sistema_tributacao { get; private set; }

        [Column(TypeName = "int")]
        public string? tipo_atividade { get; private set; }

        [Column(TypeName = "int")]
        public string? id_origem_mercadoria { get; private set; }

        [Column(TypeName = "bit")]
        public string? utiliza_uso_consumo { get; private set; }

        [Column(TypeName = "int")]
        public string? id_classificacao_cest_produto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_ws { get; private set; }
    }
}
