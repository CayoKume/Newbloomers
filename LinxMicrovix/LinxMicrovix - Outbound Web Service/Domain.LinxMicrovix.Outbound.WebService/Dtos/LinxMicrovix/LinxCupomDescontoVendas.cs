namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCupomDescontoVendas
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? id_cupom_desconto_vendas { get; set; }
        public string? id_cupom_desconto { get; set; }
        public string? identificador { get; set; }
        public string? valor { get; set; }
        public string? timestamp { get; set; }
        public string? id_vendas_pos { get; set; }

        public LinxCupomDescontoVendas()
        {
        }

        public LinxCupomDescontoVendas(string? portal, string? empresa, string? id_cupom_desconto_vendas, string? id_cupom_desconto, string? identificador, string? valor, string? timestamp, string? id_vendas_pos)
        {
            this.portal = portal;
            this.empresa = empresa;
            this.id_cupom_desconto_vendas = id_cupom_desconto_vendas;
            this.id_cupom_desconto = id_cupom_desconto;
            this.identificador = identificador;
            this.valor = valor;
            this.timestamp = timestamp;
            this.id_vendas_pos = id_vendas_pos;
        }
    }
}
