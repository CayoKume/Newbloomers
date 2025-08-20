namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxClassificacoes
    {
        public string? id_classificacao { get; set; }
        public string? desc_classificacao { get; set; }
        public string? timestamp { get; set; }
        public string? codigo_integracao_ws { get; set; }
        public string? ativo { get; set; }
    }
}
