using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaTiposCobrancaFrete", Schema = "untreated")]
    public class B2CConsultaTiposCobrancaFrete
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? codigo_tipo_cobranca_frete { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_tipo_cobranca_frete { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
