namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCstIpiFiscal
    {
        public string? portal { get; set; }
        public string? id_cst_ipi_fiscal { get; set; }
        public string? cst_ipi_fiscal { get; set; }
        public string? descricao { get; set; }
        public string? excluido { get; set; }
        public string? inicio_vigencia { get; set; }
        public string? termino_vigencia { get; set; }
        public string? cst_ipi_fiscal_inverso { get; set; }
        public string? timestamp { get; set; }

        public LinxCstIpiFiscal()
        {
        }

        public LinxCstIpiFiscal(string? portal, string? id_cst_ipi_fiscal, string? cst_ipi_fiscal, string? descricao, string? excluido, string? inicio_vigencia, string? termino_vigencia, string? cst_ipi_fiscal_inverso, string? timestamp)
        {
            this.portal = portal;
            this.id_cst_ipi_fiscal = id_cst_ipi_fiscal;
            this.cst_ipi_fiscal = cst_ipi_fiscal;
            this.descricao = descricao;
            this.excluido = excluido;
            this.inicio_vigencia = inicio_vigencia;
            this.termino_vigencia = termino_vigencia;
            this.cst_ipi_fiscal_inverso = cst_ipi_fiscal_inverso;
            this.timestamp = timestamp;
        }
    }
}
