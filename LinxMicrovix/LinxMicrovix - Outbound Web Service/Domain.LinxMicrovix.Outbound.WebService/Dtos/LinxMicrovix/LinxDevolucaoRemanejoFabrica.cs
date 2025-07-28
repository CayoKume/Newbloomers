namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabrica
    {
        public string? id_devolucao_remanejo_fabrica { get; set; }
        public string? id_devolucao_remanejo_fabrica_tipo { get; set; }
        public string? id_motivo_devolucao_fabrica { get; set; }
        public string? id_deposito { get; set; }
        public string? id_devolucao_remanejo_fabrica_status { get; set; }
        public string? empresa { get; set; }
        public string? fornecedor { get; set; }
        public string? cfop { get; set; }
        public string? serie { get; set; }
        public string? codigo_solicitacao { get; set; }
        public string? portal { get; set; }
        public string? data_solicitacao { get; set; }
        public string? timestamp { get; set; }

        public LinxDevolucaoRemanejoFabrica()
        {
        }

        public LinxDevolucaoRemanejoFabrica(string? id_devolucao_remanejo_fabrica, string? id_devolucao_remanejo_fabrica_tipo, string? id_motivo_devolucao_fabrica, string? id_deposito, string? id_devolucao_remanejo_fabrica_status, string? empresa, string? fornecedor, string? cfop, string? serie, string? codigo_solicitacao, string? portal, string? data_solicitacao, string? timestamp)
        {
            this.id_devolucao_remanejo_fabrica = id_devolucao_remanejo_fabrica;
            this.id_devolucao_remanejo_fabrica_tipo = id_devolucao_remanejo_fabrica_tipo;
            this.id_motivo_devolucao_fabrica = id_motivo_devolucao_fabrica;
            this.id_deposito = id_deposito;
            this.id_devolucao_remanejo_fabrica_status = id_devolucao_remanejo_fabrica_status;
            this.empresa = empresa;
            this.fornecedor = fornecedor;
            this.cfop = cfop;
            this.serie = serie;
            this.codigo_solicitacao = codigo_solicitacao;
            this.portal = portal;
            this.data_solicitacao = data_solicitacao;
            this.timestamp = timestamp;
        }
    }
}
