namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoObservacoes
    {
        public string? id_obs { get; set; }
        public string? portal { get; set; }
        public string? titulo_obs { get; set; }
        public string? descricao_obs { get; set; }
        public string? timestamp { get; set; }
    }
}
