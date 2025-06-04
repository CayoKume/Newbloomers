using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaProdutosCamposAdicionaisDetalhes", Schema = "linx_microvix_commerce")]
    public class B2CConsultaProdutosCamposAdicionaisDetalhes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_campo_detalhe { get; private set; }

        [Column(TypeName = "int")]
        public string? ordem { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "int")]
        public string? id_campo { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
