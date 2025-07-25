namespace Domain.Movidesk.Models.Tickets
{
    public class Client : Person
    {
        public bool isDeleted { get; set; }

        public Person? organization { get; set; }
    }
}
