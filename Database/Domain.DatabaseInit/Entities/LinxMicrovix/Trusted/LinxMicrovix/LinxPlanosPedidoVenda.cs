using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxPlanosPedidoVenda", Schema = "linx_microvix_erp")]
    public class LinxPlanosPedidoVenda
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_pedido { get; private set; }

        [Column(TypeName = "int")]
        public string? plano { get; private set; }

        [Column(TypeName = "varchar(35)")]
        public string? desc_plano { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_parcelas { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? indice_plano { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_desc_acresc_plano { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_forma_pgto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? forma_pgto { get; private set; }
    }
}
