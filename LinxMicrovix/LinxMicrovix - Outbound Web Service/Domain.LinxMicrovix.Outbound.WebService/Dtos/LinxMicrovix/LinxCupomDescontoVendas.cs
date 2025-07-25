namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCupomDescontoVendas
    {
        public string? id_cupom_desconto_venda { get; set; }
        public string? id_cupom_desconto { get; set; }
        public string? id_venda { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCupomDescontoVendas() { }

        public LinxCupomDescontoVendas(string? id_cupom_desconto_venda, string? id_cupom_desconto, string? id_venda, string? timestamp, string? portal)
        {
            this.id_cupom_desconto_venda = id_cupom_desconto_venda;
            this.id_cupom_desconto = id_cupom_desconto;
            this.id_venda = id_venda;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}