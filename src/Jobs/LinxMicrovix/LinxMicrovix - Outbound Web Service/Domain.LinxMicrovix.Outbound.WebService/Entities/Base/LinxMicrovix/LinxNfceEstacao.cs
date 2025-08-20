namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxNfceEstacao
    {
        public string? id_nfce_estacao { get; set; }
        public string? empresa { get; set; }
        public string? descricao { get; set; }
        public string? numero_pdv_tef { get; set; }
        public string? ativo { get; set; }
        public string? timestamp { get; set; }
    }
}
