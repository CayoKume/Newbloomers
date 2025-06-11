namespace Domain.Movidesk.Entities
{
    public class Attachment
    {
        public string? fileName { get; set; }
        public string? path { get; set; }
        public DateTime? createdDate { get; set; }
        public PersonTicket? createdBy { get; set; }
    }
}
