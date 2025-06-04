using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxCstIpiFiscal", Schema = "linx_microvix_erp")]
    public class LinxCstIpiFiscal
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_cst_ipi_fiscal { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cst_ipi_fiscal { get; private set; }

        [Column(TypeName = "varchar(150)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bit")]
        public string? excluido { get; private set; }

        [Column(TypeName = "datetime")]
        public string? inicio_vigencia { get; private set; }

        [Column(TypeName = "datetime")]
        public string? termino_vigencia { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cst_ipi_fiscal_inverso { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
