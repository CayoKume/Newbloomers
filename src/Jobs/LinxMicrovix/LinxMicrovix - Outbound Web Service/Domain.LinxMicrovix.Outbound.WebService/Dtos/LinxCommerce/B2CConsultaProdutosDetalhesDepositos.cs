namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositos
    {
        public string? codigoproduto { get; private set; }
        public string? empresa { get; private set; }
        public string? id_deposito { get; private set; }
        public string? saldo { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }
        public string? deposito { get; private set; }
        public string? tempo_preparacao_estoque { get; private set; }

        public B2CConsultaProdutosDetalhesDepositos() { }

        public B2CConsultaProdutosDetalhesDepositos(
            string? codigoproduto,
            string? empresa,
            string? id_deposito,
            string? saldo,
            string? timestamp,
            string? portal,
            string? deposito,
            string? tempo_preparacao_estoque
        )
        {
            this.codigoproduto = codigoproduto;
            this.empresa = empresa;
            this.id_deposito = id_deposito;
            this.saldo = saldo;
            this.timestamp = timestamp;
            this.portal = portal;
            this.deposito = deposito;
            this.tempo_preparacao_estoque = tempo_preparacao_estoque;
        }
    }
}