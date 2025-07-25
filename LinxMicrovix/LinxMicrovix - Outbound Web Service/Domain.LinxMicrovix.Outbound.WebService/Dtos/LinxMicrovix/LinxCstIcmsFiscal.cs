namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCstIcmsFiscal
    {
        public string? codigo_cst_icms { get; set; }
        public string? descricao_cst_icms { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCstIcmsFiscal() { }

        public LinxCstIcmsFiscal(string? codigo_cst_icms, string? descricao_cst_icms, string? timestamp, string? portal)
        {
            this.codigo_cst_icms = codigo_cst_icms;
            this.descricao_cst_icms = descricao_cst_icms;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}