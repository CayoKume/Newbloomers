namespace Domain.Jadlog.Entities
{
    public class Consulta
    {
        public string shipmentId { get; set; }
        public Tracking tracking { get; set; }
        public DateTime previsaoEntrega { get; set; }
        public Dictionary<string?, string?> Responses { get; set; } = new Dictionary<string?, string?>();

        public Consulta() { }

        public Consulta(DTOs.Consulta consulta, string? response)
        {
            this.shipmentId = consulta.shipmentId;
            this.tracking = new Tracking(consulta.tracking);
            this.previsaoEntrega = Convert.ToDateTime(consulta.previsaoEntrega);
            this.Responses.Add(consulta.shipmentId, response); 
        }
    }
}
