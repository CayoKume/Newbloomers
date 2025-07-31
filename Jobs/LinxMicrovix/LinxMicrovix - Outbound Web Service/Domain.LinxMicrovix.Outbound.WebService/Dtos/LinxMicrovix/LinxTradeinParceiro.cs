namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxTradeinParceiro
    {
        public string? id_tradein_parceiro { get; set; }
        public string? nome_parceiro { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxTradeinParceiro() { }

        public LinxTradeinParceiro(
            string? id_tradein_parceiro,
            string? nome_parceiro,
            string? timestamp,
            string? portal)
        {
            this.id_tradein_parceiro = id_tradein_parceiro;
            this.nome_parceiro = nome_parceiro;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}