using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxCupomDesconto", Schema = "linx_microvix_erp")]
    public class LinxCupomDesconto
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cupom_desconto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? cupom { get; private set; }

        [Column(TypeName = "varchar(255)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? percentual_desconto { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_inicial_vigencia { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_final_vigencia { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_original { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_disponivel { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_vendedor { get; private set; }

        [Column(TypeName = "bit")]
        public string? disponivel { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
