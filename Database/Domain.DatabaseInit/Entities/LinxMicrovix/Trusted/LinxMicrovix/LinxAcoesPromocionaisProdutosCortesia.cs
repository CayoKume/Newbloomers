using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxAcoesPromocionaisProdutosCortesia", Schema = "linx_microvix_erp")]
    public class LinxAcoesPromocionaisProdutosCortesia
    {
        [Column(TypeName = "datetime")]
        public string lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_acoes_promocionais_produtos_cortesia { get; private set; }

        [Column(TypeName = "int")]
        public string? id_acoes_promocionais { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? id_combinacao_produto { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
