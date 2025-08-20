namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxRespostaVenda
    {
        public string? id_resposta_venda { get; set; }
        public string? id_pergunta_venda { get; set; }
        public string? descricao_resposta { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxRespostaVenda() { }

        public LinxRespostaVenda(
            string? id_resposta_venda,
            string? id_pergunta_venda,
            string? descricao_resposta,
            string? timestamp,
            string? portal)
        {
            this.id_resposta_venda = id_resposta_venda;
            this.id_pergunta_venda = id_pergunta_venda;
            this.descricao_resposta = descricao_resposta;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}