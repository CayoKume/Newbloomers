namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxB2CStatus
    {
        public string? id_status { get; set; }
        public string? descricao_status { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxB2CStatus()
        {
        }

        public LinxB2CStatus(string? id_status, string? descricao_status, string? timestamp, string? portal)
        {
            this.id_status = id_status;
            this.descricao_status = descricao_status;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}
