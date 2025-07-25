namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaUnidade
    {
        public string? unidade { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaUnidade() { }

        public B2CConsultaUnidade(string? unidade, string? timestamp, string? portal)
        {
            this.unidade = unidade;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}