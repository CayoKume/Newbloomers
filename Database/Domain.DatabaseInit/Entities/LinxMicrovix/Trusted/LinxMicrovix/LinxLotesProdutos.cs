using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxLotesProdutos", Schema = "linx_microvix_erp")]
    public class LinxLotesProdutos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_lote { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigo_produto { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? lote { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_fabricacao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_vencimento { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
