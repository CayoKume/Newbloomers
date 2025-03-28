namespace Domain.Jadlog.Entities
{
    public class Tracking
    {
        public string codigo { get; set; }
        public string shipmentId { get; set; }
        public string dacte { get; set; }
        public DateTime dtEmissao { get; set; }
        public string status { get; set; }
        public decimal valor { get; set; }
        public decimal peso { get; set; }
        public Recebedor recebedor { get; set; }
        public List<Evento> eventos { get; set; } = new List<Evento>();
        public List<Volume> volumes { get; set; } = new List<Volume>();

        public Tracking() { }

        public Tracking(DTOs.Tracking tracking)
        {
            this.codigo = tracking.codigo;
            this.shipmentId = tracking.shipmentId;
            this.dacte = tracking.dacte;
            this.dtEmissao = Convert.ToDateTime(tracking.dtEmissao);
            this.status = tracking.status;
            this.valor = tracking.valor;
            this.peso = tracking.peso;
            this.recebedor = new Recebedor(tracking.recebedor);

            foreach(var evento in tracking.eventos)
            {
                this.eventos.Add(new Evento(evento));
            }

            foreach (var volume in tracking.volumes)
            {
                this.volumes.Add(new Volume(volume));
            }
        }
    }
}
