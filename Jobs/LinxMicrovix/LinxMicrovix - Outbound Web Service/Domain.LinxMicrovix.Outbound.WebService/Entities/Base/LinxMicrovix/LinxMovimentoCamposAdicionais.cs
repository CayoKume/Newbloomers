namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoCamposAdicionais
    {
        public string? id_ordservprod { get; set; }
        public string? transacao { get; set; }
        public string? paciente { get; set; }
        public string? codigo_gerencial { get; set; }
        public string? timestamp { get; set; }
    }
}
