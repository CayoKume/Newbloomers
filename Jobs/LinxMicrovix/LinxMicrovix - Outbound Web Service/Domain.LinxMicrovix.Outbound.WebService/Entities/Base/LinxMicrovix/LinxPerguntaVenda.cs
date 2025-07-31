namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxPerguntaVenda
    {
        public string? id_pergunta_venda { get; set; }
        public string? portal { get; set; }
        public string? descricao_pergunta { get; set; }
        public string? timestamp { get; set; }
    }
}
