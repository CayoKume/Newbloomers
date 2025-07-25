namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCores
    {
        public string? codigo_cor { get; set; }
        public string? nome_cor { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCores() { }

        public LinxCores(string? codigo_cor, string? nome_cor, string? timestamp, string? portal)
        {
            this.codigo_cor = codigo_cor;
            this.nome_cor = nome_cor;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}