namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosCampanhas
    {
        public string? codigo_campanha { get; private set; }
        public string? nome_campanha { get; private set; }
        public string? vigencia_inicio { get; private set; }
        public string? vigencia_fim { get; private set; }
        public string? observacao { get; private set; }
        public string? ativo { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosCampanhas() { }

        public B2CConsultaProdutosCampanhas(
            string? codigo_campanha,
            string? nome_campanha,
            string? vigencia_inicio,
            string? vigencia_fim,
            string? observacao,
            string? ativo,
            string? timestamp,
            string? portal
        )
        {
            this.codigo_campanha = codigo_campanha;
            this.nome_campanha = nome_campanha;
            this.vigencia_inicio = vigencia_inicio;
            this.vigencia_fim = vigencia_fim;
            this.observacao = observacao;
            this.ativo = ativo;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}