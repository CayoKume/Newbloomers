namespace Domain.Movidesk.Dtos.Tickets
{
    public class Action
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public string? origin { get; set; }
        public string? description { get; set; }
        public string? status { get; set; }
        public string? justification { get; set; }
        public string? createdDate { get; set; }
        public Createdby? createdBy { get; set; }
        public string? isDeleted { get; set; }
        public Attachment[]? attachments { get; set; }
        public Satisfactionsurveyrespons[]? satisfactionSurveyResponses { get; set; }
        public Customfieldvalue[]? customFieldValues { get; set; }
    }
}
