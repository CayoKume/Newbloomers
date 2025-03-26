using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaProdutosCodebar", Schema = "linx_microvix_commerce")]
    public class B2CConsultaProdutosCodebar
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codebar { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_produtos_codebar { get; private set; }

        [Column(TypeName = "bit")]
        public string? principal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? tipo_codebar { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
