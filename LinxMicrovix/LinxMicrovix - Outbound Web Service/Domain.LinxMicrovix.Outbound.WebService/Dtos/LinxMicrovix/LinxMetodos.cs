namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMetodos
    {
        public string? id_metodo { get; set; }
        public string? nome_metodo { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMetodos() { }

        public LinxMetodos(string? id_metodo, string? nome_metodo, string? timestamp, string? portal)
        {
            this.id_metodo = id_metodo;
            this.nome_metodo = nome_metodo;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}