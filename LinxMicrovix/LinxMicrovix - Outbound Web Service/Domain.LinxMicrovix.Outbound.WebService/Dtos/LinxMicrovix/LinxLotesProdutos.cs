namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxLotesProdutos
    {
        public string? id_lote_produto { get; set; }
        public string? codigoproduto { get; set; }
        public string? numero_lote { get; set; }
        public string? data_validade { get; set; }
        public string? quantidade { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxLotesProdutos() { }

        public LinxLotesProdutos(string? id_lote_produto, string? codigoproduto, string? numero_lote,
                                 string? data_validade, string? quantidade, string? timestamp, string? portal)
        {
            this.id_lote_produto = id_lote_produto;
            this.codigoproduto = codigoproduto;
            this.numero_lote = numero_lote;
            this.data_validade = data_validade;
            this.quantidade = quantidade;
            this.timestamp = timestamp;
            this.portal = portal;
        }

    }
}