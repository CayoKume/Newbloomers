namespace Domain.Movidesk.Entities
{
    public class Contact
    {
        public Int32? id { get; set; }
        public string? contactType { get; set; }
        public string? contact { get; set; }
        public bool? isDefault { get; set; }
    }
}
