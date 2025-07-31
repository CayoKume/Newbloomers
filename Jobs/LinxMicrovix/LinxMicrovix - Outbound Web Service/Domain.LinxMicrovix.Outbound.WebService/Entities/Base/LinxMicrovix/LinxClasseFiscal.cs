namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxClasseFiscal
    {
        public string? portal { get; set; }
        public string? id_classe_fiscal { get; set; }
        public string? descricao { get; set; }
        public string? excluido { get; set; }
        public string? timestamp { get; set; }
    }
}
