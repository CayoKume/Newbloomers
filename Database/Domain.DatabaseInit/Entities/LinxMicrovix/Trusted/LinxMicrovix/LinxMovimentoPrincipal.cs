using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxMovimentoPrincipal", Schema = "linx_microvix_erp")]
    public class LinxMovimentoPrincipal
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_movimento_principal { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto_manutencao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? id_pergunta_venda { get; private set; }

        [Column(TypeName = "int")]
        public string? id_resposta_venda { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_fidelidade_cashback { get; private set; }

        [Column(TypeName = "int")]
        public string? plano_fidelidade_cashback { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? remessa_pedido_compra { get; private set; }

        [Column(TypeName = "int")]
        public string? id_motivo_desconto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_nota { get; private set; }
    }
}
