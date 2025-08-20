
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxECF
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_ecf { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? ecf { get; private set; }
        public string? numeroserie { get; private set; }
        public string? indice_sangria { get; private set; }
        public Int32? modelo { get; private set; }
        public string? nome { get; private set; }
        public string? indice_suprimento { get; private set; }
        public bool? ativo { get; private set; }
        public string? indice_sinal { get; private set; }
        public string? indice_antecipacao { get; private set; }
        public string? indice_cartao_credito { get; private set; }
        public string? empresa_ecf { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxECF() { }

        public LinxECF(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxECF record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_ecf = CustomConvertersExtensions.ConvertToInt32Validation(record.id_ecf);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.ecf = CustomConvertersExtensions.ConvertToInt32Validation(record.ecf);
            this.modelo = CustomConvertersExtensions.ConvertToInt32Validation(record.modelo);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.nome = record.nome;
            this.numeroserie = record.numeroserie;
            this.indice_sangria = record.indice_sangria;
            this.indice_suprimento = record.indice_suprimento;
            this.indice_sinal = record.indice_sinal;
            this.indice_antecipacao = record.indice_antecipacao;
            this.indice_cartao_credito = record.indice_cartao_credito;
            this.empresa_ecf = record.empresa_ecf;
        }
    }
}
