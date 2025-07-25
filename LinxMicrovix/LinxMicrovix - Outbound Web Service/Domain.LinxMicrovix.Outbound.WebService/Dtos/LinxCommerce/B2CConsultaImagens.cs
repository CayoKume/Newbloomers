namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaImagens
    {
        public string? id_imagem { get; private set; }
        public string? md5 { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }
        public string? url_imagem_blob { get; private set; }

        public B2CConsultaImagens() { }

        public B2CConsultaImagens(
            string? id_imagem,
            string? md5,
            string? timestamp,
            string? portal,
            string? url_imagem_blob
        )
        {
            this.id_imagem = id_imagem;
            this.md5 = md5;
            this.timestamp = timestamp;
            this.portal = portal;
            this.url_imagem_blob = url_imagem_blob;
        }
    }
}