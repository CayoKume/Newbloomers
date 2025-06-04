using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxDevolucaoRemanejoFabricaItem", Schema = "linx_microvix_erp")]
    public class LinxDevolucaoRemanejoFabricaItem
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_devolucao_remanejo_fabrica_item { get; private set; }

        [Column(TypeName = "int")]
        public string? id_devolucao_remanejo_fabrica { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_produto_franqueadora { get; private set; }

        [Column(TypeName = "int")]
        public string? quantidade { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codebar { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? serial { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
