namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoReshop
    {
        public string? id_movimento_campanha_reshop { get; set; }
        public string? id_campanha { get; set; }
        public string? identificador { get; set; }
        public string? nome { get; set; }
        public string? descricao { get; set; }
        public string? aplicar_desconto_venda { get; set; }
        public string? valor_desconto_subtotal { get; set; }
        public string? valor_desconto_completo { get; set; }
        public string? timestamp { get; set; }
    }
}
