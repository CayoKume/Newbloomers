namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhes
    {
        public string? id_configuracao_tributaria_detalhe { get; set; }
        public string? id_configuracao_tributaria { get; set; }
        public string? tipo_tributacao { get; set; }
        public string? aliquota { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxConfiguracoesTributariasDetalhes() { }

        public LinxConfiguracoesTributariasDetalhes(string? id_configuracao_tributaria_detalhe, string? id_configuracao_tributaria, string? tipo_tributacao, string? aliquota, string? timestamp, string? portal)
        {
            this.id_configuracao_tributaria_detalhe = id_configuracao_tributaria_detalhe;
            this.id_configuracao_tributaria = id_configuracao_tributaria;
            this.tipo_tributacao = tipo_tributacao;
            this.aliquota = aliquota;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}