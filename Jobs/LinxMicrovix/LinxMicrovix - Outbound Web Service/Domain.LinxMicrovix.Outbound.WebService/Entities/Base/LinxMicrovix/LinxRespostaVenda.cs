namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxRespostaVenda
    {
        public string? id_resposta_venda { get; set; }
        public string? portal { get; set; }
        public string? descricao_resposta { get; set; }
        public string? id_pergunta_venda { get; set; }
        public string? timestamp { get; set; }
    }
}
