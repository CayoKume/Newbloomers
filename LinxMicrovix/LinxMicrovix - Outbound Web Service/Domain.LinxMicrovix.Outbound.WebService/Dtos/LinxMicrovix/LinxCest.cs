namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCest
    {
        public string? portal { get; set; }
        public string? id_cest { get; set; }
        public string? descricao { get; set; }
        public string? cest { get; set; }
        public string? id_segmento_mercadoria_bem { get; set; }
        public string? ativo { get; set; }
        public string? timestamp { get; set; }

        public LinxCest()
        {
        }

        public LinxCest(string? portal, string? id_cest, string? descricao, string? cest, string? id_segmento_mercadoria_bem, string? ativo, string? timestamp)
        {
            this.portal = portal;
            this.id_cest = id_cest;
            this.descricao = descricao;
            this.cest = cest;
            this.id_segmento_mercadoria_bem = id_segmento_mercadoria_bem;
            this.ativo = ativo;
            this.timestamp = timestamp;
        }
    }
}
