using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxECF
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_ecf { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? ecf { get; private set; }

        [LengthValidation(length: 30, propertyName: "numeroserie")]
        public string? numeroserie { get; private set; }

        [LengthValidation(length: 4, propertyName: "indice_sangria")]
        public string? indice_sangria { get; private set; }

        public Int32? modelo { get; private set; }

        [LengthValidation(length: 30, propertyName: "nome")]
        public string? nome { get; private set; }

        [LengthValidation(length: 4, propertyName: "indice_suprimento")]
        public string? indice_suprimento { get; private set; }

        public bool? ativo { get; private set; }

        [LengthValidation(length: 53, propertyName: "indice_sinal")]
        public string? indice_sinal { get; private set; }

        [LengthValidation(length: 50, propertyName: "indice_antecipacao")]
        public string? indice_antecipacao { get; private set; }

        [LengthValidation(length: 50, propertyName: "indice_cartao_credito")]
        public string? indice_cartao_credito { get; private set; }

        [LengthValidation(length: 50, propertyName: "empresa_ecf")]
        public string? empresa_ecf { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxECF() { }

        public LinxECF(
            List<ValidationResult> listValidations,
            string? id_ecf,
            string? empresa,
            string? ecf,
            string? numeroserie,
            string? indice_sangria,
            string? modelo,
            string? nome,
            string? indice_suprimento,
            string? ativo,
            string? indice_sinal,
            string? indice_antecipacao,
            string? indice_cartao_credito,
            string? empresa_ecf,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_ecf =
                ConvertToInt32Validation.IsValid(id_ecf, "id_ecf", listValidations) ?
                Convert.ToInt32(id_ecf) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.ecf =
                ConvertToInt32Validation.IsValid(ecf, "ecf", listValidations) ?
                Convert.ToInt32(ecf) :
                0;

            this.modelo =
                ConvertToInt32Validation.IsValid(modelo, "modelo", listValidations) ?
                Convert.ToInt32(modelo) :
                0;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome = nome;
            this.numeroserie = numeroserie;
            this.indice_sangria = indice_sangria;
            this.indice_suprimento = indice_suprimento;
            this.indice_sinal = indice_sinal;
            this.indice_antecipacao = indice_antecipacao;
            this.indice_cartao_credito = indice_cartao_credito;
            this.empresa_ecf = empresa_ecf;
        }
    }
}
