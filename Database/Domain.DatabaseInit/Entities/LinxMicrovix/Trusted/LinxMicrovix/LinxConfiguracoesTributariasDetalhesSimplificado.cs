using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxConfiguracoesTributariasDetalhesSimplificado", Schema = "linx_microvix_erp")]
    public class LinxConfiguracoesTributariasDetalhesSimplificado
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_config_tributaria_detalhe { get; private set; }

        [Column(TypeName = "int")]
        public string? id_config_tributaria { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? cod_natureza_operacao { get; private set; }

        [Column(TypeName = "int")]
        public string? id_classe_fiscal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cst_icms_fiscal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_csosn_fiscal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cfop_fiscal { get; private set; }

        [Column(TypeName = "bit")]
        public string? ipi_credito { get; private set; }

        [Column(TypeName = "bit")]
        public string? icms_credito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? perc_reducao_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? margem_st { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
