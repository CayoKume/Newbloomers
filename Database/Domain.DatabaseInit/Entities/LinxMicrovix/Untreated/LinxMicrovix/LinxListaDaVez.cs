using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxListaDaVez", Schema = "untreated")]
    public class LinxListaDaVez
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_vendedor { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data { get; private set; }

        [Column(TypeName = "varchar(103)")]
        public string? motivo_nao_venda { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_ocorrencias { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_hora_ini_atend { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_hora_fim_atend { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? obs { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? desc_produto_neg { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_produto_neg { get; private set; }
    }
}
