namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClientesFornecClasses
    {
        public string? id_classe { get; set; }
        public string? descricao_classe { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxClientesFornecClasses() { }

        public LinxClientesFornecClasses(string? id_classe, string? descricao_classe, string? timestamp, string? portal)
        {
            this.id_classe = id_classe;
            this.descricao_classe = descricao_classe;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}