using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxSerialVenda
    {
        public string? id_serial_venda { get; private set; }
        public string? portal { get; private set; }
        public string? transacao { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? serial { get; private set; }
        public string? timestamp { get; private set; }

        public LinxSerialVenda() { }

        public LinxSerialVenda(
            string? id_serial_venda,
            string? portal,
            string? transacao,
            string? codigoproduto,
            string? serial,
            string? timestamp
        )
        {
            this.id_serial_venda = id_serial_venda;
            this.portal = portal;
            this.transacao = transacao;
            this.codigoproduto = codigoproduto;
            this.serial = serial;
            this.timestamp = timestamp;
        }
    }
}