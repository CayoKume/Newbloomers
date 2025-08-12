

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoPrincipal
    {
        public string? id_movimento_principal { get; private set; }
        public string? identificador { get; private set; }
        public string? codigoproduto_manutencao { get; private set; }
        public string? timestamp { get; private set; }
        public string? id_pergunta_venda { get; private set; }
        public string? id_resposta_venda { get; private set; }
        public string? total_fidelidade_cashback { get; private set; }
        public string? plano_fidelidade_cashback { get; private set; }
        public string? remessa_pedido_compra { get; private set; }
        public string? id_motivo_desconto { get; private set; }
        public string? valor_nota { get; private set; }

        public LinxMovimentoPrincipal() { }

        public LinxMovimentoPrincipal(
            string? id_movimento_principal,
            string? identificador,
            string? codigoproduto_manutencao,
            string? timestamp,
            string? id_pergunta_venda,
            string? id_resposta_venda,
            string? total_fidelidade_cashback,
            string? plano_fidelidade_cashback,
            string? remessa_pedido_compra,
            string? id_motivo_desconto,
            string? valor_nota
        )
        {
            this.id_movimento_principal =  id_movimento_principal;
            this.identificador = identificador;
            this.codigoproduto_manutencao = codigoproduto_manutencao;
            this.timestamp = timestamp;
            this.id_pergunta_venda = id_pergunta_venda;
            this.id_resposta_venda = id_resposta_venda;
            this.total_fidelidade_cashback = total_fidelidade_cashback;
            this.plano_fidelidade_cashback = plano_fidelidade_cashback;
            this.remessa_pedido_compra = remessa_pedido_compra;
            this.id_motivo_desconto = id_motivo_desconto;
            this.valor_nota = valor_nota;
        }
    }
}