namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxUsuarios
    {
        public string? usuario_id { get; set; }
        public string? usuario_login { get; set; }
        public string? usuario_nome { get; set; }
        public string? usuario_email { get; set; }
        public string? usuario_grupo_id { get; set; }
        public string? grupo_usuarios { get; set; }
        public string? usuario_supervisor { get; set; }
        public string? usuario_doc { get; set; }
        public string? vendedor { get; set; }
        public string? data_criacao { get; set; }
        public string? desativado { get; set; }
        public string? empresas { get; set; }
        public string? portal { get; set; }
        public string? timestamp { get; set; }
    }
}
