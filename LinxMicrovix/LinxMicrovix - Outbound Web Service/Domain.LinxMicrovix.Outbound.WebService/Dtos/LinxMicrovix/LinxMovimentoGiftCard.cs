namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoGiftCard
    {
        public string? id_movimento_gift_card { get; set; }
        public string? id_movimento { get; set; }
        public string? id_gift_card { get; set; }
        public string? valor_gift_card { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoGiftCard()
        {
        }

        public LinxMovimentoGiftCard(
            string? id_movimento_gift_card,
            string? id_movimento,
            string? id_gift_card,
            string? valor_gift_card,
            string? timestamp,
            string? portal)
        {
            this.id_movimento_gift_card = id_movimento_gift_card;
            this.id_movimento = id_movimento;
            this.id_gift_card = id_gift_card;
            this.valor_gift_card = valor_gift_card;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}