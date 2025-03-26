using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxProdutosPromocoes", Schema = "linx_microvix_erp")]
    public class LinxProdutosPromocoes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? cod_produto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? preco_promocao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_inicio_promocao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_termino_promocao { get; private set; }

        [Key]
        [Column(TypeName = "datetime")]
        public string? data_cadastro_promocao { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? promocao_ativa { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? id_campanha { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_campanha { get; private set; }

        [Column(TypeName = "bit")]
        public string? promocao_opcional { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? custo_total_campanha { get; private set; }
    }
}
