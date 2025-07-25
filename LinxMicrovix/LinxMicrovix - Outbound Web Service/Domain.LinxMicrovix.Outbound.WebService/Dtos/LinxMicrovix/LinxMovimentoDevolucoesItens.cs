namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoDevolucoesItens
    {
        public string? id_movimento_devolucao_item { get; set; }
        public string? id_movimento { get; set; }
        public string? codigoproduto { get; set; }
        public string? quantidade { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoDevolucoesItens() { }

        public LinxMovimentoDevolucoesItens(string? id_movimento_devolucao_item, string? id_movimento, string? codigoproduto, string? quantidade, string? timestamp, string? portal)
        {
            this.id_movimento_devolucao_item = id_movimento_devolucao_item;
            this.id_movimento = id_movimento;
            this.codigoproduto = codigoproduto;
            this.quantidade = quantidade;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}