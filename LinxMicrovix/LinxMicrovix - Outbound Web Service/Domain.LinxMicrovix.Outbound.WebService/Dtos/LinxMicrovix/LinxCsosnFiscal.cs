namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCsosnFiscal
    {
        public string? codigo_csosn { get; set; }
        public string? descricao_csosn { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCsosnFiscal() { }

        public LinxCsosnFiscal(string? codigo_csosn, string? descricao_csosn, string? timestamp, string? portal)
        {
            this.codigo_csosn = codigo_csosn;
            this.descricao_csosn = descricao_csosn;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}