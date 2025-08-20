namespace Domain.Movidesk.Models.Tickets
{
    public class Action
    {
        public int id { get; set; }
        public int type { get; set; }
        public int origin { get; set; }
        public string? description { get; set; }
        public string? status { get; set; }
        public string? justification { get; set; }
        public DateTime createdDate { get; set; }
        public bool isDeleted { get; set; }

        public Person? createdBy { get; set; }

        public List<Attachment>? attachments { get; set; }
        public List<CustomFieldValue>? customFieldValues { get; set; }
    }
}