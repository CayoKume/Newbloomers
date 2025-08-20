namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoSerial
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? identificador { get; set; }
        public string? transacao { get; set; }
        public string? serial { get; set; }
        public string? timestamp { get; set; }
    }
}
