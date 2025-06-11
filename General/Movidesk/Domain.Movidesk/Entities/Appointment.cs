namespace Domain.Movidesk.Entities
{
    public class Appointment
    {
        public Int32? id { get; set; }
        public string? activity { get; set; }
        public DateTime? date { get; set; }
        public TimeOnly? periodStart { get; set; }
        public TimeOnly? periodEnd { get; set; }
        public TimeOnly? workTime { get; set; }
        public decimal? accountedTime { get; set; }
        public string? workTypeName { get; set; }
        public PersonTicket? createdBy { get; set; }
        public Team? createdByTeam { get; set; }
    }
}
