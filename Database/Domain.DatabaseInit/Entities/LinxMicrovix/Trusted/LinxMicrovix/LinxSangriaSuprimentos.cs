using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxSangriaSuprimentos", Schema = "linx_microvix_erp")]
    public class LinxSangriaSuprimentos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? usuario { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? obs { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? cancelado { get; private set; }

        [Column(TypeName = "bit")]
        public string? conferido { get; private set; }

        [Column(TypeName = "bigint")]
        public string? cod_historico { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? desc_historico { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_sangria_suprimentos { get; private set; }
    }
}
