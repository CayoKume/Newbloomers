namespace Domain.Movidesk.Dtos.Tickets
{
    public class Attachment
    {
        public string? fileName { get; set; }
        public string? path { get; set; }
        public Createdby? createdBy { get; set; }
        public string? createdDate { get; set; }
    }
}
