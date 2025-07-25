namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxConfiguracoesTributarias
    {
        public string? id_configuracao_tributaria { get; set; }
        public string? nome_configuracao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxConfiguracoesTributarias() { }

        public LinxConfiguracoesTributarias(string? id_configuracao_tributaria, string? nome_configuracao, string? timestamp, string? portal)
        {
            this.id_configuracao_tributaria = id_configuracao_tributaria;
            this.nome_configuracao = nome_configuracao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}