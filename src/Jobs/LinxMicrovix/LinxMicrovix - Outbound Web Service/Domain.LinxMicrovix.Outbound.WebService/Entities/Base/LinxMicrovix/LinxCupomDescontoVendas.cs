namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxCupomDescontoVendas
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? id_cupom_desconto_vendas { get; set; }
        public string? id_cupom_desconto { get; set; }
        public string? identificador { get; set; }
        public string? valor { get; set; }
        public string? timestamp { get; set; }
        public string? id_vendas_pos { get; set; }
    }
}
