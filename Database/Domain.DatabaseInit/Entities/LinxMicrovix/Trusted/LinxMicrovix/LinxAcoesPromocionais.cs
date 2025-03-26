using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxAcoesPromocionais", Schema = "linx_microvix_erp")]
    public class LinxAcoesPromocionais
    {
        [Column(TypeName = "datetime")]
        public string lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_acoes_promocionais { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? vigencia_inicio { get; private set; }

        [Column(TypeName = "datetime")]
        public string? vigencia_fim { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? observacao { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativa { get; private set; }

        [Column(TypeName = "bit")]
        public string? excluida { get; private set; }

        [Column(TypeName = "bit")]
        public string? integrada { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_integrada { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_pago_franqueadora { get; private set; }
    }
}
