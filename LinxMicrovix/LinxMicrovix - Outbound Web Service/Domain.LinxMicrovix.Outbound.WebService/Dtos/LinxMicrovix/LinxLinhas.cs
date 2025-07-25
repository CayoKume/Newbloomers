namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxLinhas
    {
        public string? codigo_linha { get; set; }
        public string? nome_linha { get; set; }
        public string? timestamp { get; set; }
        public string? setores { get; set; }
        public string? portal { get; set; }

        public LinxLinhas() { }

        public LinxLinhas(string? codigo_linha, string? nome_linha, string? timestamp, string? setores, string? portal)
        {
            this.codigo_linha = codigo_linha;
            this.nome_linha = nome_linha;
            this.timestamp = timestamp;
            this.setores = setores;
            this.portal = portal;
        }

    }
}