namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClientesFornecClasses
    {
        public string? portal { get; set; }
        public string? cod_cliente { get; set; }
        public string? cod_classe { get; set; }
        public string? nome_classe { get; set; }
        public string? timestamp { get; set; }

        public LinxClientesFornecClasses()
        {
        }

        public LinxClientesFornecClasses(string? portal, string? cod_cliente, string? cod_classe, string? nome_classe, string? timestamp)
        {
            this.portal = portal;
            this.cod_cliente = cod_cliente;
            this.cod_classe = cod_classe;
            this.nome_classe = nome_classe;
            this.timestamp = timestamp;
        }
    }
}
