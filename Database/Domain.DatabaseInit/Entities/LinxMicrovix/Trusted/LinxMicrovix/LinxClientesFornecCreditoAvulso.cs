using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxClientesFornecCreditoAvulso", Schema = "linx_microvix_erp")]
    public class LinxClientesFornecCreditoAvulso
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_cliente { get; private set; }

        [Column(TypeName = "int")]
        public string? controle { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? data { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? cd { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? motivo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }
    }
}
