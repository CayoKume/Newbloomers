namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoDevolucoesItens
    {
        public string? id_movimento_devolucoes_itens { get; set; }
        public string? portal { get; set; }
        public string? identificador_venda { get; set; }
        public string? cnpj_emp { get; set; }
        public string? identificador_devolucao { get; set; }
        public string? codigoproduto { get; set; }
        public string? transacao_origem { get; set; }
        public string? transacao_devolucao { get; set; }
        public string? qtde_devolvida { get; set; }
        public string? timestamp { get; set; }

        public LinxMovimentoDevolucoesItens()
        {
        }

        public LinxMovimentoDevolucoesItens(string? id_movimento_devolucoes_itens, string? portal, string? identificador_venda, string? cnpj_emp, string? identificador_devolucao, string? codigoproduto, string? transacao_origem, string? transacao_devolucao, string? qtde_devolvida, string? timestamp)
        {
            this.id_movimento_devolucoes_itens = id_movimento_devolucoes_itens;
            this.portal = portal;
            this.identificador_venda = identificador_venda;
            this.cnpj_emp = cnpj_emp;
            this.identificador_devolucao = identificador_devolucao;
            this.codigoproduto = codigoproduto;
            this.transacao_origem = transacao_origem;
            this.transacao_devolucao = transacao_devolucao;
            this.qtde_devolvida = qtde_devolvida;
            this.timestamp = timestamp;
        }
    }
}
