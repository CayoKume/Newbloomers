namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaCodigoRastreio
    {
        public string? id_pedido { get; set; }
        public string? documento { get; set; }
        public string? serie { get; set; }
        public string? codigo_rastreio { get; set; }
        public string? sequencia_volume { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
    }
}
