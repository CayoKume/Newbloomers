namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoDevolucoesItens
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
    }
}
