using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaVendedores", Schema = "untreated")]
    public class B2CConsultaVendedores
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_vendedor { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_vendedor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? comissao_produtos { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? comissao_servicos { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public string? comissionado { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
