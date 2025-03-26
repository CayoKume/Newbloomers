using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaClientesSaldoLinx", Schema = "untreated")]
    public class B2CConsultaClientesSaldoLinx
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_cliente_erp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_cliente_b2c { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
