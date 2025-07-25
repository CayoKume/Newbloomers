namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaColecoes
    {
        public string? codigo_colecao { get; private set; }
        public string? nome_colecao { get; private set; }
        public string? timestamp { get; private set; }
        public string? marcas { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaColecoes() { }

        public B2CConsultaColecoes(
            string? codigo_colecao,
            string? nome_colecao,
            string? timestamp,
            string? marcas,
            string? portal
        )
        {
            this.codigo_colecao = codigo_colecao;
            this.nome_colecao = nome_colecao;
            this.timestamp = timestamp;
            this.marcas = marcas;
            this.portal = portal;
        }
    }
}