namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCstIpiFiscal
    {
        public string? codigo_cst_ipi { get; set; }
        public string? descricao_cst_ipi { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCstIpiFiscal() { }

        public LinxCstIpiFiscal(string? codigo_cst_ipi, string? descricao_cst_ipi, string? timestamp, string? portal)
        {
            this.codigo_cst_ipi = codigo_cst_ipi;
            this.descricao_cst_ipi = descricao_cst_ipi;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}