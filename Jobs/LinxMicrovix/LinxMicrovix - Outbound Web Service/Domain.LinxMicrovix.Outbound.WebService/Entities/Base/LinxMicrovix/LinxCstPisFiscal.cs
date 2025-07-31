namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxCstPisFiscal
    {
        public string? portal { get; set; }
        public string? id_cst_pis_fiscal { get; set; }
        public string? cst_pis_fiscal { get; set; }
        public string? descricao { get; set; }
        public string? excluido { get; set; }
        public string? inicio_vigencia { get; set; }
        public string? termino_vigencia { get; set; }
        public string? timestamp { get; set; }
    }
}
