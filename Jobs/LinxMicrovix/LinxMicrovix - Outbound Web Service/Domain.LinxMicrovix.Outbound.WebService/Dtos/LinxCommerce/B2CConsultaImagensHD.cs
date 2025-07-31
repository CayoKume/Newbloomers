namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaImagensHD
    {
        public string? identificador_imagem { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? timestamp { get; private set; }
        public string? url_imagem_blob { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaImagensHD() { }

        public B2CConsultaImagensHD(
            string? identificador_imagem,
            string? codigoproduto,
            string? timestamp,
            string? url_imagem_blob,
            string? portal
        )
        {
            this.identificador_imagem = identificador_imagem;
            this.codigoproduto = codigoproduto;
            this.timestamp = timestamp;
            this.url_imagem_blob = url_imagem_blob;
            this.portal = portal;
        }
    }
}