namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxTrocaUnificadaResumoVendas
    {
        public string? id_troca_unificada_resumo_vendas { get; set; }
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? token { get; set; }
        public string? identificador { get; set; }
        public string? documento { get; set; }
        public string? serie { get; set; }
        public string? data_venda { get; set; }
        public string? documento_cliente { get; set; }
        public string? venda_cancelada { get; set; }
        public string? timestamp { get; set; }
    }
}
