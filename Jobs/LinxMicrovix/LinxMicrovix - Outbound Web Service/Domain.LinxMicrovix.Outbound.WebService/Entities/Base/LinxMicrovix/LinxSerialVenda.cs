namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxSerialVenda
    {
        public string? id_serial_venda { get; set; }
        public string? portal { get; set; }
        public string? transacao { get; set; }
        public string? codigoproduto { get; set; }
        public string? serial { get; set; }
        public string? timestamp { get; set; }
    }
}
