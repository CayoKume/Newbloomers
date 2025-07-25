namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCstCofinsFiscal
    {
        public string? codigo_cst_cofins { get; set; }
        public string? descricao_cst_cofins { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCstCofinsFiscal() { }

        public LinxCstCofinsFiscal(string? codigo_cst_cofins, string? descricao_cst_cofins, string? timestamp, string? portal)
        {
            this.codigo_cst_cofins = codigo_cst_cofins;
            this.descricao_cst_cofins = descricao_cst_cofins;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}