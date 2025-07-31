namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxLotesProdutos
    {
        public string? id_lote { get; set; }
        public string? codigo_produto { get; set; }
        public string? lote { get; set; }
        public string? identificador { get; set; }
        public string? transacao { get; set; }
        public string? data_fabricacao { get; set; }
        public string? data_vencimento { get; set; }
        public string? portal { get; set; }
        public string? timestamp { get; set; }

        public LinxLotesProdutos()
        {
        }

        public LinxLotesProdutos(string? id_lote, string? codigo_produto, string? lote, string? identificador, string? transacao, string? data_fabricacao, string? data_vencimento, string? portal, string? timestamp)
        {
            this.id_lote = id_lote;
            this.codigo_produto = codigo_produto;
            this.lote = lote;
            this.identificador = identificador;
            this.transacao = transacao;
            this.data_fabricacao = data_fabricacao;
            this.data_vencimento = data_vencimento;
            this.portal = portal;
            this.timestamp = timestamp;
        }
    }
}
