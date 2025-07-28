namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxValesComprasEnviadosAPI
    {
        public string? numero_controle { get; set; }
        public string? valor_vale { get; set; }
        public string? doc_cliente { get; set; }
        public string? status_vale { get; set; }
        public string? codigo_portal_resgate { get; set; }
        public string? codigo_empresa_resgate { get; set; }
        public string? codigo_usuario_resgate { get; set; }
        public string? codigo_vale_empresa_resgate { get; set; }
        public string? data_criacao { get; set; }
        public string? timestamp { get; set; }
        public string? cnpj_empresa_resgate { get; set; }
        public string? data_resgate { get; set; }
    }
}
