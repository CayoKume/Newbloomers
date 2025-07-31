using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxProdutosLotes
    {
        public string? portal { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? empresa { get; private set; }
        public string? lote { get; private set; }
        public string? deposito { get; private set; }
        public string? saldo_disponivel { get; private set; }
        public string? timestamp { get; private set; }

        public LinxProdutosLotes() { }

        public LinxProdutosLotes(
            string? portal,
            string? codigoproduto,
            string? empresa,
            string? lote,
            string? deposito,
            string? saldo_disponivel,
            string? timestamp
        )
        {
            this.portal = portal;
            this.codigoproduto = codigoproduto;
            this.empresa = empresa;
            this.lote = lote;
            this.deposito = deposito;
            this.saldo_disponivel = saldo_disponivel;
            this.timestamp = timestamp;
        }
    }
}