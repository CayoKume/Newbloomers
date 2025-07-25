namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCfopFiscal
    {
        public string? codigo_cfop { get; set; }
        public string? descricao_cfop { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCfopFiscal() { }

        public LinxCfopFiscal(string? codigo_cfop, string? descricao_cfop, string? timestamp, string? portal)
        {
            this.codigo_cfop = codigo_cfop;
            this.descricao_cfop = descricao_cfop;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}