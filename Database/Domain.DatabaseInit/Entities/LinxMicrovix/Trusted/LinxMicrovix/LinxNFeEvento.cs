using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxNFeEvento", Schema = "linx_microvix_erp")]
    public class LinxNFeEvento
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_nfe_evento { get; private set; }

        [Column(TypeName = "int")]
        public string? id_nfe { get; private set; }

        [Column(TypeName = "varchar(6)")]
        public string? codigo_tipo { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? xml { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_emissao { get; private set; }

        [Column(TypeName = "char(5)")]
        public string? hora_emissao { get; private set; }
    }
}
