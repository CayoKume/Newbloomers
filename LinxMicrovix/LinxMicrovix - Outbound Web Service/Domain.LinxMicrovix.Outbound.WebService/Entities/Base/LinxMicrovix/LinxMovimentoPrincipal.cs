namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoPrincipal
    {
        public string? id_movimento_principal { get; set; }
        public string? identificador { get; set; }
        public string? codigoproduto_manutencao { get; set; }
        public string? timestamp { get; set; }
        public string? id_pergunta_venda { get; set; }
        public string? id_resposta_venda { get; set; }
        public string? total_fidelidade_cashback { get; set; }
        public string? plano_fidelidade_cashback { get; set; }
        public string? remessa_pedido_compra { get; set; }
        public string? id_motivo_desconto { get; set; }
        public string? valor_nota { get; set; }
    }
}
