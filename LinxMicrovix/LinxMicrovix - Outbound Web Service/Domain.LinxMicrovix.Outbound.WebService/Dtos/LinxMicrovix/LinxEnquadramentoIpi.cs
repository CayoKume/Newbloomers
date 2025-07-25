namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxEnquadramentoIpi
    {
        public string? codigo_enquadramento_ipi { get; set; }
        public string? descricao_enquadramento_ipi { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxEnquadramentoIpi() { }

        public LinxEnquadramentoIpi(string? codigo_enquadramento_ipi, string? descricao_enquadramento_ipi, string? timestamp, string? portal)
        {
            this.codigo_enquadramento_ipi = codigo_enquadramento_ipi;
            this.descricao_enquadramento_ipi = descricao_enquadramento_ipi;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}