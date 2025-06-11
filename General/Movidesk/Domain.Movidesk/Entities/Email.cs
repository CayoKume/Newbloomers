namespace Domain.Movidesk.Entities
{
    public class Email
    {
        public Int32? id { get; set; }
        public string? emailType { get; set; }
        public string? email { get; set; }
        public bool? isDefault { get; set; }
    }
}
