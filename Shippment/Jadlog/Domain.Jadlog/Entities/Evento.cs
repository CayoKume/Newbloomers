namespace Domain.Jadlog.Entities
{
    public class Evento
    {
        public DateTime data { get; set; }
        public string status { get; set; }
        public string unidade { get; set; }

        public Evento() { }

        public Evento(DTOs.Evento evento)
        {
            this.data = Convert.ToDateTime(evento.data);
            this.status = evento.status;
            this.unidade = evento.unidade;
        }
    }
}
