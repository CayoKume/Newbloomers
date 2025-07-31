namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxB2CPedidosStatus
    {
        public string? id { get; set; }
        public string? id_status { get; set; }
        public string? id_pedido { get; set; }
        public string? data_hora { get; set; }
        public string? anotacao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxB2CPedidosStatus()
        {
        }

        public LinxB2CPedidosStatus(string? id, string? id_status, string? id_pedido, string? data_hora, string? anotacao, string? timestamp, string? portal)
        {
            this.id = id;
            this.id_status = id_status;
            this.id_pedido = id_pedido;
            this.data_hora = data_hora;
            this.anotacao = anotacao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}
