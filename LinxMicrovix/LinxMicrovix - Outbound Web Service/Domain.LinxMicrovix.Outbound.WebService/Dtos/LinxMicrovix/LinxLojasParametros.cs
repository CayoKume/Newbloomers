namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxLojasParametros
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? percentual_minimo_antecipacao { get; set; }
        public string? timestamp { get; set; }

        public LinxLojasParametros()
        {
        }

        public LinxLojasParametros(string? portal, string? empresa, string? percentual_minimo_antecipacao, string? timestamp)
        {
            this.portal = portal;
            this.empresa = empresa;
            this.percentual_minimo_antecipacao = percentual_minimo_antecipacao;
            this.timestamp = timestamp;
        }
    }
}
