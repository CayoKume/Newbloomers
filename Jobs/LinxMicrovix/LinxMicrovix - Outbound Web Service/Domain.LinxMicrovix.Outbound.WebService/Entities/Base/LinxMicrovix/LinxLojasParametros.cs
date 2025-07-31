namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxLojasParametros
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? percentual_minimo_antecipacao { get; set; }
        public string? timestamp { get; set; }
    }
}
