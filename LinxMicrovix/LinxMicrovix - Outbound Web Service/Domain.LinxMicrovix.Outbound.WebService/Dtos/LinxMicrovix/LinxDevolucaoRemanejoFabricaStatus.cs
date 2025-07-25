namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaStatus
    {
        public string? id_devolucao_remanejo_fabrica_status { get; set; }
        public string? descricao_status { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxDevolucaoRemanejoFabricaStatus() { }

        public LinxDevolucaoRemanejoFabricaStatus(string? id_devolucao_remanejo_fabrica_status, string? descricao_status, string? timestamp, string? portal)
        {
            this.id_devolucao_remanejo_fabrica_status = id_devolucao_remanejo_fabrica_status;
            this.descricao_status = descricao_status;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}