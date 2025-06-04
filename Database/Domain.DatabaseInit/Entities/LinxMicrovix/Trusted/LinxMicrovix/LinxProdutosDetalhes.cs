using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxProdutosDetalhes", Schema = "linx_microvix_erp")]
    public class LinxProdutosDetalhes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_produto { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? cod_barra { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? preco_custo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? preco_venda { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? custo_medio { get; private set; }

        [Column(TypeName = "int")]
        public string? id_config_tributaria { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? desc_config_tributaria { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? despesas1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_minima { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_maxima { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? ipi { get; private set; }

        [Column(TypeName = "int")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }
    }
}
