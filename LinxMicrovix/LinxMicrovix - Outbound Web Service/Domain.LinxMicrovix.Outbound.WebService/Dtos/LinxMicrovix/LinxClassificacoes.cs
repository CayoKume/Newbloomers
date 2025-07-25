namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClassificacoes
    {
        public string? codigo_classificacao { get; set; }
        public string? nome_classificacao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxClassificacoes() { }

        public LinxClassificacoes(string? codigo_classificacao, string? nome_classificacao, string? timestamp, string? portal)
        {
            this.codigo_classificacao = codigo_classificacao;
            this.nome_classificacao = nome_classificacao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}