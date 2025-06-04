using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaPedidosIdentificador", Schema = "untreated")]
    public class B2CConsultaPedidosIdentificador
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_venda { get; private set; }

        [Key]
        [Column(TypeName = "varchar(40)")]
        public string? order_id { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_cliente { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_frete { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_origem { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
