namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxSeries
    {
        public string? portal { get; set; }
        public string? serie { get; set; }
        public string? id_modelo_nf { get; set; }
        public string? timestamp { get; set; }
    }
}
