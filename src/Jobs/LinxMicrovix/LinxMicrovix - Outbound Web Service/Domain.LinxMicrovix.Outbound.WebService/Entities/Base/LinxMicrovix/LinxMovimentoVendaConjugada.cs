namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoVendaConjugada
    {
        public string? identificador_produto { get; set; }
        public string? identificador_servico { get; set; }
        public string? timestamp { get; set; }
    }
}
