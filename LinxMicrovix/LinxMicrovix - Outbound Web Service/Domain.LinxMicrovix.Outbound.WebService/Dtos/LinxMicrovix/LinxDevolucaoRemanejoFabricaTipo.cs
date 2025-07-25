namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaTipo
    {
        public string? id_devolucao_remanejo_fabrica_tipo { get; set; }
        public string? descricao_tipo { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxDevolucaoRemanejoFabricaTipo() { }

        public LinxDevolucaoRemanejoFabricaTipo(string? id_devolucao_remanejo_fabrica_tipo, string? descricao_tipo, string? timestamp, string? portal)
        {
            this.id_devolucao_remanejo_fabrica_tipo = id_devolucao_remanejo_fabrica_tipo;
            this.descricao_tipo = descricao_tipo;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}