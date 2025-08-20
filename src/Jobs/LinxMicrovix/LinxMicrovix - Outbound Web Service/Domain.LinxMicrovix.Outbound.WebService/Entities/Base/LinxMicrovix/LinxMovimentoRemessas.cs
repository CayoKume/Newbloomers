namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoRemessas
    {
        public string? id_remessas { get; set; }
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? id_tipo { get; set; }
        public string? identificador_remessa { get; set; }
        public string? status { get; set; }
        public string? status_descricao { get; set; }
        public string? timestamp { get; set; }
    }
}
