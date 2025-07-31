namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaStatus
    {
        public string? id_devolucao_remanejo_fabrica_status { get; set; }
        public string? id_devolucao_remanejo_fabrica_tipo { get; set; }
        public string? descricao { get; set; }
        public string? timestamp { get; set; }

        public LinxDevolucaoRemanejoFabricaStatus()
        {
        }

        public LinxDevolucaoRemanejoFabricaStatus(string? id_devolucao_remanejo_fabrica_status, string? id_devolucao_remanejo_fabrica_tipo, string? descricao, string? timestamp)
        {
            this.id_devolucao_remanejo_fabrica_status = id_devolucao_remanejo_fabrica_status;
            this.id_devolucao_remanejo_fabrica_tipo = id_devolucao_remanejo_fabrica_tipo;
            this.descricao = descricao;
            this.timestamp = timestamp;
        }
    }
}
