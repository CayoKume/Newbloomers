

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxProdutosSerial
    {
        public string? codigoproduto { get; private set; }
        public string? portal { get; private set; }
        public string? empresa { get; private set; }
        public string? serial { get; private set; }
        public string? id_deposito { get; private set; }
        public string? saldo { get; private set; }
        public string? timestamp { get; private set; }

        public LinxProdutosSerial() { }

        public LinxProdutosSerial(
            string? codigoproduto,
            string? portal,
            string? empresa,
            string? serial,
            string? id_deposito,
            string? saldo,
            string? timestamp
        )
        {
            this.codigoproduto = codigoproduto;
            this.portal = portal;
            this.empresa = empresa;
            this.serial = serial;
            this.id_deposito = id_deposito;
            this.saldo = saldo;
            this.timestamp = timestamp;
        }
    }
}