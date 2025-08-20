namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxTrocaUnificadaResumoBaixa
    {
        public string? portal_baixa { get; set; }
        public string? empresa_baixa { get; set; }
        public string? cnpj_empresa_baixa { get; set; }
        public string? id_troca_baixa { get; set; }
        public string? id_troca_unificada_resumo_vendas_itens { get; set; }
        public string? data_troca_baixa { get; set; }
        public string? transacao_baixa { get; set; }
        public string? descricao_empresa_baixa { get; set; }
        public string? timestamp { get; set; }
    }
}
