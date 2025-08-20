namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaFormasPagamento
    {
        public string? cod_forma_pgto { get; private set; }
        public string? forma_pgto { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaFormasPagamento() { }

        public B2CConsultaFormasPagamento(
            string? cod_forma_pgto,
            string? forma_pgto,
            string? timestamp,
            string? portal
        )
        {
            this.cod_forma_pgto = cod_forma_pgto;
            this.forma_pgto = forma_pgto;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}