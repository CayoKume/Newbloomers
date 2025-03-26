using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxMovimentoOrigemDevolucoes", Schema = "linx_microvix_erp")]
    public class LinxMovimentoOrigemDevolucoes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? nota_origem { get; private set; }

        [Column(TypeName = "int")]
        public string? ecf_origem { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_origem { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie_origem { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
