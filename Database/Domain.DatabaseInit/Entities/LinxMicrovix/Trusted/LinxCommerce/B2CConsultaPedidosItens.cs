using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaPedidosItens", Schema = "linx_microvix_commerce")]
    public class B2CConsultaPedidosItens
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_pedido_item { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_pedido { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? vl_unitario { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
