namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCstPisFiscal
    {
        public string? codigo_cst_pis { get; set; }
        public string? descricao_cst_pis { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCstPisFiscal() { }

        public LinxCstPisFiscal(string? codigo_cst_pis, string? descricao_cst_pis, string? timestamp, string? portal)
        {
            this.codigo_cst_pis = codigo_cst_pis;
            this.descricao_cst_pis = descricao_cst_pis;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}