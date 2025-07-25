namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabrica
    {
        public string? id_devolucao_remanejo_fabrica { get; set; }
        public string? empresa { get; set; }
        public string? tipo_devolucao { get; set; }
        public string? status_devolucao { get; set; }
        public string? data_devolucao { get; set; }
        public string? observacao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxDevolucaoRemanejoFabrica() { }

        public LinxDevolucaoRemanejoFabrica(string? id_devolucao_remanejo_fabrica, string? empresa, string? tipo_devolucao, string? status_devolucao, string? data_devolucao, string? observacao, string? timestamp, string? portal)
        {
            this.id_devolucao_remanejo_fabrica = id_devolucao_remanejo_fabrica;
            this.empresa = empresa;
            this.tipo_devolucao = tipo_devolucao;
            this.status_devolucao = status_devolucao;
            this.data_devolucao = data_devolucao;
            this.observacao = observacao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}