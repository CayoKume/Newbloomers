using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoSerial
    {
        public string? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? identificador { get; private set; }
        public string? transacao { get; private set; }
        public string? serial { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoSerial() { }

        public LinxMovimentoSerial(
            string? portal,
            string? cnpj_emp,
            string? identificador,
            string? transacao,
            string? serial,
            string? timestamp
        )
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.identificador = identificador;
            this.transacao = transacao;
            this.serial = serial;
            this.timestamp = timestamp;
        }
    }
}