using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxFidelidade
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? id_fidelidade_parceiro_log { get; private set; }

        public DateTime? data_transacao { get; private set; }

        public Int32? operacao { get; private set; }

        [LengthValidation(length: 4, propertyName: "aprovado_barramento")]
        public string? aprovado_barramento { get; private set; }

        public decimal? valor_monetario { get; private set; }

        [LengthValidation(length: 100, propertyName: "numero_cartao")]
        public string? numero_cartao { get; private set; }

        public Guid? identificador_movimento { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxFidelidade() { }

        public LinxFidelidade(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? id_fidelidade_parceiro_log,
            string? data_transacao,
            string? operacao,
            string? aprovado_barramento,
            string? valor_monetario,
            string? numero_cartao,
            string? identificador_movimento,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_fidelidade_parceiro_log =
                ConvertToInt32Validation.IsValid(id_fidelidade_parceiro_log, "id_fidelidade_parceiro_log", listValidations) ?
                Convert.ToInt32(id_fidelidade_parceiro_log) :
                0;

            this.operacao =
                ConvertToInt32Validation.IsValid(operacao, "operacao", listValidations) ?
                Convert.ToInt32(operacao) :
                0;

            this.data_transacao =
                ConvertToDateTimeValidation.IsValid(data_transacao, "data_transacao", listValidations) ?
                Convert.ToDateTime(data_transacao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.valor_monetario =
                ConvertToDecimalValidation.IsValid(valor_monetario, "valor_monetario", listValidations) ?
                Convert.ToDecimal(valor_monetario, new CultureInfo("en-US")) :
                0;

            this.identificador_movimento =
                String.IsNullOrEmpty(identificador_movimento) ? null
                : Guid.Parse(identificador_movimento);

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cnpj_emp = cnpj_emp;
            this.aprovado_barramento = aprovado_barramento;
            this.numero_cartao = numero_cartao;
        }
    }
}
