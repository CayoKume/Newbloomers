

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoBaixa
    {
        public string? portal_baixa { get; private set; }
        public string? empresa_baixa { get; private set; }
        public string? cnpj_empresa_baixa { get; private set; }
        public string? id_troca_baixa { get; private set; }
        public string? id_troca_unificada_resumo_vendas_itens { get; private set; }
        public string? data_troca_baixa { get; private set; }
        public string? transacao_baixa { get; private set; }
        public string? descricao_empresa_baixa { get; private set; }
        public string? timestamp { get; private set; }

        public LinxTrocaUnificadaResumoBaixa() { }

        public LinxTrocaUnificadaResumoBaixa(
            string? portal_baixa,
            string? empresa_baixa,
            string? cnpj_empresa_baixa,
            string? id_troca_baixa,
            string? id_troca_unificada_resumo_vendas_itens,
            string? data_troca_baixa,
            string? transacao_baixa,
            string? descricao_empresa_baixa,
            string? timestamp
        )
        {
            this.portal_baixa = portal_baixa;
            this.empresa_baixa = empresa_baixa;
            this.cnpj_empresa_baixa = cnpj_empresa_baixa;
            this.id_troca_baixa = id_troca_baixa;
            this.id_troca_unificada_resumo_vendas_itens = id_troca_unificada_resumo_vendas_itens;
            this.data_troca_baixa = data_troca_baixa;
            this.transacao_baixa = transacao_baixa;
            this.descricao_empresa_baixa = descricao_empresa_baixa;
            this.timestamp = timestamp;
        }
    }
}