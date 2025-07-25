namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoReshopItens
    {
        public string? id_movimento_campanha_reshop_item { get; private set; }
        public string? id_campanha { get; private set; }
        public string? identificador { get; private set; }
        public string? valor_unitario { get; private set; }
        public string? valor_desconto_item { get; private set; }
        public string quantidade { get; private set; }
        public string? valor_original { get; private set; }
        public string? timestamp { get; private set; }
        public string? ordem { get; private set; }

        public LinxMovimentoReshopItens() { }

        public LinxMovimentoReshopItens(
            string? id_movimento_campanha_reshop_item,
            string? id_campanha,
            string? identificador,
            string? valor_unitario,
            string? valor_desconto_item,
            string quantidade,
            string? valor_original,
            string? timestamp,
            string? ordem
        )
        {
            this.id_movimento_campanha_reshop_item = id_movimento_campanha_reshop_item;
            this.id_campanha = id_campanha;
            this.identificador = identificador;
            this.valor_unitario = valor_unitario;
            this.valor_desconto_item = valor_desconto_item;
            this.quantidade = quantidade;
            this.valor_original = valor_original;
            this.timestamp = timestamp;
            this.ordem = ordem;
        }
    }
}