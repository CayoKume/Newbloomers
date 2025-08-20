namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosDepositos
    {
        public string? id_deposito { get; private set; }
        public string? nome_deposito { get; private set; }
        public string? disponivel { get; private set; }
        public string? disponivel_transferencia { get; private set; }
        public string? disponivel_franquias { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosDepositos() { }

        public B2CConsultaProdutosDepositos(
            string? id_deposito,
            string? nome_deposito,
            string? disponivel,
            string? disponivel_transferencia,
            string? disponivel_franquias,
            string? timestamp,
            string? portal
        )
        {
            this.id_deposito = id_deposito;
            this.nome_deposito = nome_deposito;
            this.disponivel = disponivel;
            this.disponivel_transferencia = disponivel_transferencia;
            this.disponivel_franquias = disponivel_franquias;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}