namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxDevolucaoRemanejoFabrica
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
    }
}
