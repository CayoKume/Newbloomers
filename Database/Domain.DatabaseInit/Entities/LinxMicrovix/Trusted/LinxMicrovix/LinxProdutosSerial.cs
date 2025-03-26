using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxProdutosSerial", Schema = "linx_microvix_erp")]
    public class LinxProdutosSerial
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? serial { get; private set; }

        [Column(TypeName = "int")]
        public string? id_deposito { get; private set; }

        [Column(TypeName = "bit")]
        public string? saldo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
