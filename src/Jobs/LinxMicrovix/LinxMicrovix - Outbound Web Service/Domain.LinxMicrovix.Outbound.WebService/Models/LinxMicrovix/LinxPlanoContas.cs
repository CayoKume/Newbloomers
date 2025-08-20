
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPlanoContas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public string? cnpj { get; private set; }
        public Int32? id_conta { get; private set; }
        public string? nome_conta { get; private set; }
        public string? sintetica { get; private set; }
        public string? indice { get; private set; }
        public string? ativa { get; private set; }
        public string? fluxo_caixa { get; private set; }
        public string? conta_contabil { get; private set; }
        public Int32? id_natureza_conta { get; private set; }
        public bool? conta_bancaria { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPlanoContas() { }

        public LinxPlanoContas(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPlanoContas record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_conta = CustomConvertersExtensions.ConvertToInt32Validation(record.id_conta);
            this.id_natureza_conta = CustomConvertersExtensions.ConvertToInt32Validation(record.id_natureza_conta);
            this.conta_bancaria = CustomConvertersExtensions.ConvertToBooleanValidation(record.conta_bancaria);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.conta_contabil = record.conta_contabil;
            this.fluxo_caixa = record.fluxo_caixa;
            this.ativa = record.ativa;
            this.indice = record.indice;
            this.sintetica = record.sintetica;
            this.nome_conta = record.nome_conta;
            this.cnpj = record.cnpj;
        }
    }
}
