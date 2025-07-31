namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCstIcmsFiscal
    {
        public string? portal { get; set; }
        public string? id_cst_icms_fiscal { get; set; }
        public string? cst_icms_fiscal { get; set; }
        public string? descricao { get; set; }
        public string? substituicao_tributaria { get; set; }
        public string? excluido { get; set; }
        public string? timestamp { get; set; }

        public LinxCstIcmsFiscal()
        {
        }

        public LinxCstIcmsFiscal(string? portal, string? id_cst_icms_fiscal, string? cst_icms_fiscal, string? descricao, string? substituicao_tributaria, string? excluido, string? timestamp)
        {
            this.portal = portal;
            this.id_cst_icms_fiscal = id_cst_icms_fiscal;
            this.cst_icms_fiscal = cst_icms_fiscal;
            this.descricao = descricao;
            this.substituicao_tributaria = substituicao_tributaria;
            this.excluido = excluido;
            this.timestamp = timestamp;
        }
    }
}
