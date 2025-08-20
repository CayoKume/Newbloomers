namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxNcm
    {
        public string? portal { get; set; }
        public string? codigo { get; set; }
        public string? descricao { get; set; }
        public string? codigo_genero { get; set; }
        public string? ativo { get; set; }
        public string? id_ncm { get; set; }
        public string? timestamp { get; set; }
    }
}
