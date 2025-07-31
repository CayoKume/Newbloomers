namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxNFeEvento
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_nfe_evento { get; set; }
        public string? id_nfe { get; set; }
        public string? codigo_tipo { get; set; }
        public string? xml { get; set; }
        public string? timestamp { get; set; }
        public string? data_emissao { get; set; }
        public string? hora_emissao { get; set; }
    }
}
