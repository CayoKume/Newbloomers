namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxEnquadramentoIpi
    {
        public string? portal { get; set; }
        public string? id_enquadramento_ipi { get; set; }
        public string? codigo { get; set; }
        public string? descricao { get; set; }
        public string? timestamp { get; set; }

        public LinxEnquadramentoIpi()
        {
        }

        public LinxEnquadramentoIpi(string? portal, string? id_enquadramento_ipi, string? codigo, string? descricao, string? timestamp)
        {
            this.portal = portal;
            this.id_enquadramento_ipi = id_enquadramento_ipi;
            this.codigo = codigo;
            this.descricao = descricao;
            this.timestamp = timestamp;
        }
    }
}
