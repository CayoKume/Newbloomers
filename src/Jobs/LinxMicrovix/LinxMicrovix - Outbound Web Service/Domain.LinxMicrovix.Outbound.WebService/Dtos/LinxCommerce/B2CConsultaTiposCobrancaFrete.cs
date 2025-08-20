namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFrete
    {
        public string? codigo_tipo_cobranca_frete { get; private set; }
        public string? nome_tipo_cobranca_frete { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaTiposCobrancaFrete() { }

        public B2CConsultaTiposCobrancaFrete(string? codigo_tipo_cobranca_frete, string? nome_tipo_cobranca_frete, string? timestamp, string? portal)
        {
            this.codigo_tipo_cobranca_frete = codigo_tipo_cobranca_frete;
            this.nome_tipo_cobranca_frete = nome_tipo_cobranca_frete;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}