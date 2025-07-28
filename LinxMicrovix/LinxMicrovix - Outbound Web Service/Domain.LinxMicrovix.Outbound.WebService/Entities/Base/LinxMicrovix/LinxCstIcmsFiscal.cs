namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxCstIcmsFiscal
    {
        public string? portal { get; set; }
        public string? id_cst_icms_fiscal { get; set; }
        public string? cst_icms_fiscal { get; set; }
        public string? descricao { get; set; }
        public string? substituicao_tributaria { get; set; }
        public string? excluido { get; set; }
        public string? timestamp { get; set; }
    }
}
