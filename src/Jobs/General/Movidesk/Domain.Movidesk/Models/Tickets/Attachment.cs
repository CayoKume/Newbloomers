using System;

namespace Domain.Movidesk.Models.Tickets
{
    public class Attachment
    {
        public string? fileName { get; set; }
        public string? path { get; set; }
        public DateTime createdDate { get; set; }
        public Person? createdBy { get; set; }
    }
}