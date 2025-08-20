

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoReshop
    {
        public string? id_movimento_campanha_reshop { get; private set; }
        public string? id_campanha { get; private set; }
        public string? identificador { get; private set; }
        public string? nome { get; private set; }
        public string? descricao { get; private set; }
        public string? aplicar_desconto_venda { get; private set; }
        public string? valor_desconto_subtotal { get; private set; }
        public string? valor_desconto_completo { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoReshop() { }

        public LinxMovimentoReshop(
            string? id_movimento_campanha_reshop,
            string? id_campanha,
            string? identificador,
            string? nome,
            string? descricao,
            string? aplicar_desconto_venda,
            string? valor_desconto_subtotal,
            string? valor_desconto_completo,
            string? timestamp
        )
        {
            this.id_movimento_campanha_reshop = id_movimento_campanha_reshop;
            this.id_campanha = id_campanha;
            this.identificador = identificador;
            this.nome = nome;
            this.descricao = descricao;
            this.aplicar_desconto_venda = aplicar_desconto_venda;
            this.valor_desconto_subtotal = valor_desconto_subtotal;
            this.valor_desconto_completo = valor_desconto_completo;
            this.timestamp = timestamp;
        }
    }
}