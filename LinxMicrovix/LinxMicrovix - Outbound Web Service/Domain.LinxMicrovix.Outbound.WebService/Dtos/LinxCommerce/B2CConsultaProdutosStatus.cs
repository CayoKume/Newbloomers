namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosStatus
    {
        public string? codigoproduto { get; private set; }
        public string? referencia { get; private set; }
        public string? ativo { get; private set; }
        public string? b2c { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosStatus() { }

        public B2CConsultaProdutosStatus(string? codigoproduto, string? referencia, string? ativo, string? b2c, string? timestamp, string? portal)
        {
            this.codigoproduto = codigoproduto;
            this.referencia = referencia;
            this.ativo = ativo;
            this.b2c = b2c;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}