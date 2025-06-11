namespace Domain.Movidesk.Entities
{
    public class Action
    {
        public Int32? id { get; set; }
        public Int32? type { get; set; }
        public Int32? origin { get; set; }

        public string? description { get; set; }
        public string? status { get; set; }
        public string? justification { get; set; }

        public DateTime? createdDate { get; set; }

        public bool? isDeleted { get; set; }

        public List<Appointment>? timeAppointments { get; set; }
        public List<SurveyResponse>? satisfactionSurveyResponses { get; set; }
        public List<Attachment>? attachments { get; set; }
        public List<Expense>? expenses { get; set; }
        public PersonTicket? createdBy { get; set; }
        public List<FamilyTicket>? parentTickets { get; set; }
        public List<FamilyTicket>? childrenTickets { get; set; }
        public List<CustomFieldValue>? customFieldValues { get; set; }
    }
}
