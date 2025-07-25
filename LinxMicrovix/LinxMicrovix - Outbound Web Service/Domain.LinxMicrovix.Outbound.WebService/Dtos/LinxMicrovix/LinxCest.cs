namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCest
    {
        public string? codigo_cest { get; set; }
        public string? descricao_cest { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCest() { }

        public LinxCest(string? codigo_cest, string? descricao_cest, string? timestamp, string? portal)
        {
            this.codigo_cest = codigo_cest;
            this.descricao_cest = descricao_cest;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}