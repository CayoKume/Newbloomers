namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxB2CStatus
    {
        public string? id_status { get; set; }
        public string? descricao_status { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
    }
}
