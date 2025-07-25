namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxColecoes
    {
        public string? codigo_colecao { get; set; }
        public string? nome_colecao { get; set; }
        public string? timestamp { get; set; }
        public string? marcas { get; set; }
        public string? portal { get; set; }

        public LinxColecoes() { }

        public LinxColecoes(string? codigo_colecao, string? nome_colecao, string? timestamp, string? marcas, string? portal)
        {
            this.codigo_colecao = codigo_colecao;
            this.nome_colecao = nome_colecao;
            this.timestamp = timestamp;
            this.marcas = marcas;
            this.portal = portal;
        }
    }
}