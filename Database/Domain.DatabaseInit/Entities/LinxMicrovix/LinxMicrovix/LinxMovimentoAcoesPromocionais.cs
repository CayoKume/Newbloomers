using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxMovimentoAcoesPromocionais", Schema = "untreated")]
    public class LinxMovimentoAcoesPromocionais
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? transacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_acoes_promocionais { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? desconto_item { get; private set; }

        [Column(TypeName = "int")]
        public Int32? quantidade { get; private set; }

        public LinxMovimentoAcoesPromocionais() { }

        public LinxMovimentoAcoesPromocionais(
            List<ValidationResult> listValidations,
            string? identificador,
            string? portal,
            string? cnpj_emp,
            string? transacao,
            string? id_acoes_promocionais,
            string? desconto_item,
            string? quantidade
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.transacao =
                ConvertToInt32Validation.IsValid(transacao, "transacao", listValidations) ?
                Convert.ToInt32(transacao) :
                0;

            this.id_acoes_promocionais =
                ConvertToInt32Validation.IsValid(id_acoes_promocionais, "id_acoes_promocionais", listValidations) ?
                Convert.ToInt32(id_acoes_promocionais) :
                0;

            this.quantidade =
                ConvertToInt32Validation.IsValid(quantidade, "quantidade", listValidations) ?
                Convert.ToInt32(quantidade) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.desconto_item =
                ConvertToDecimalValidation.IsValid(desconto_item, "desconto_item", listValidations) ?
                Convert.ToDecimal(desconto_item) :
                0;

            this.cnpj_emp = cnpj_emp;
        }
    }
}
