using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxAcoesPromocionais
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? id_acoes_promocionais { get; private set; }

        [LengthValidation(length: 100, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public DateTime? vigencia_inicio { get; private set; }

        public DateTime? vigencia_fim { get; private set; }

        public string? observacao { get; private set; }

        public bool? ativa { get; private set; }

        public bool? excluida { get; private set; }

        public bool? integrada { get; private set; }

        public Int32? qtde_integrada { get; private set; }

        public decimal? valor_pago_franqueadora { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxAcoesPromocionais() { }

        public LinxAcoesPromocionais(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? id_acoes_promocionais,
            string? descricao,
            string? vigencia_inicio,
            string? vigencia_fim,
            string? observacao,
            string? ativa,
            string? excluida,
            string? integrada,
            string? qtde_integrada,
            string? valor_pago_franqueadora
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_acoes_promocionais =
                ConvertToInt32Validation.IsValid(id_acoes_promocionais, "id_acoes_promocionais", listValidations) ?
                Convert.ToInt32(id_acoes_promocionais) :
                0;

            this.vigencia_inicio =
                ConvertToDateTimeValidation.IsValid(vigencia_inicio, "vigencia_inicio", listValidations) ?
                Convert.ToDateTime(vigencia_inicio) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.vigencia_fim =
                ConvertToDateTimeValidation.IsValid(vigencia_fim, "vigencia_fim", listValidations) ?
                Convert.ToDateTime(vigencia_fim) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.ativa =
                ConvertToBooleanValidation.IsValid(ativa, "ativa", listValidations) ?
                Convert.ToBoolean(ativa) :
                false;

            this.excluida =
                ConvertToBooleanValidation.IsValid(excluida, "excluida", listValidations) ?
                Convert.ToBoolean(excluida) :
                false;

            this.integrada =
                ConvertToBooleanValidation.IsValid(integrada, "integrada", listValidations) ?
                Convert.ToBoolean(integrada) :
                false;

            this.qtde_integrada =
                ConvertToInt32Validation.IsValid(qtde_integrada, "qtde_integrada", listValidations) ?
                Convert.ToInt32(qtde_integrada) :
                0;

            this.valor_pago_franqueadora =
                ConvertToDecimalValidation.IsValid(valor_pago_franqueadora, "valor_pago_franqueadora", listValidations) ?
                Convert.ToDecimal(valor_pago_franqueadora, new CultureInfo("en-US")) :
                0;

            this.cnpj_emp = cnpj_emp;
            this.descricao = descricao;
            this.observacao = observacao;
        }
    }
}
