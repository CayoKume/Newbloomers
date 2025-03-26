using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxTrocaUnificadaResumoVendasItens", Schema = "linx_microvix_erp")]
    public class LinxTrocaUnificadaResumoVendasItens
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? id_troca_unificada_resumo_vendas_itens { get; private set; }

        [Column(TypeName = "bigint")]
        public string? id_troca_unificada_resumo_vendas { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? serial { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_liquido { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_validade { get; private set; }

        [Column(TypeName = "bit")]
        public string? venda_referenciada { get; private set; }

        [Column(TypeName = "bit")]
        public string? token_utilizado { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? quantidade { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
