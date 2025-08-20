
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxAcoesPromocionais
    {
        public DateTime lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? id_acoes_promocionais { get; private set; }
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

        public LinxAcoesPromocionais(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxAcoesPromocionais record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_acoes_promocionais = CustomConvertersExtensions.ConvertToInt32Validation(record.id_acoes_promocionais);
            this.vigencia_inicio =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.vigencia_inicio);
            this.vigencia_fim =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.vigencia_fim);
            this.ativa = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativa);
            this.excluida = CustomConvertersExtensions.ConvertToBooleanValidation(record.excluida);
            this.integrada = CustomConvertersExtensions.ConvertToBooleanValidation(record.integrada);
            this.qtde_integrada = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_integrada);
            this.valor_pago_franqueadora = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_pago_franqueadora);
            this.cnpj_emp = record.cnpj_emp;
            this.descricao = record.descricao;
            this.observacao = record.observacao;
        }
    }
}
