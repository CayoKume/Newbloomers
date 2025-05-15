using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxPlanoContas
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? empresa { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj")]
        public string? cnpj { get; private set; }

        public Int32? id_conta { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_conta")]
        public string? nome_conta { get; private set; }

        [LengthValidation(length: 1, propertyName: "sintetica")]
        public string? sintetica { get; private set; }

        [LengthValidation(length: 150, propertyName: "indice")]
        public string? indice { get; private set; }

        [LengthValidation(length: 1, propertyName: "ativa")]
        public string? ativa { get; private set; }

        [LengthValidation(length: 1, propertyName: "fluxo_caixa")]
        public string? fluxo_caixa { get; private set; }

        [LengthValidation(length: 20, propertyName: "conta_contabil")]
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

        public LinxPlanoContas(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? cnpj,
            string? id_conta,
            string? nome_conta,
            string? sintetica,
            string? indice,
            string? ativa,
            string? fluxo_caixa,
            string? conta_contabil,
            string? id_natureza_conta,
            string? conta_bancaria,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_conta =
                ConvertToInt32Validation.IsValid(id_conta, "id_conta", listValidations) ?
                Convert.ToInt32(id_conta) :
                0;

            this.id_natureza_conta =
                ConvertToInt32Validation.IsValid(id_natureza_conta, "id_natureza_conta", listValidations) ?
                Convert.ToInt32(id_natureza_conta) :
                0;

            this.conta_bancaria =
                ConvertToBooleanValidation.IsValid(conta_bancaria, "conta_bancaria", listValidations) ?
                Convert.ToBoolean(conta_bancaria) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.conta_contabil = conta_contabil;
            this.fluxo_caixa = fluxo_caixa;
            this.ativa = ativa;
            this.indice = indice;
            this.sintetica = sintetica;
            this.nome_conta = nome_conta;
            this.cnpj = cnpj;
        }
    }
}
