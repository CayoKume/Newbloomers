namespace Domain.Movidesk.Dtos.Tickets
{
    public class Client : Createdby
    {
        public string? isDeleted { get; set; }

        public Createdby? organization { get; set; }
    }
}
