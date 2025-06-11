namespace Domain.Movidesk.Entities
{
    public class Expense
    {
        public Int32? id { get; set; }
        public string? type { get; set; }
        public string? serviceReport { get; set; }
        public Team createdByTeam { get; set; }
        public DateTime? date { get; set; }
        public Int32? quantity { get; set; }
        public decimal? value { get; set; }
    }
}
