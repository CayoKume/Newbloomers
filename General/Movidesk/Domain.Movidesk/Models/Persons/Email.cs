namespace Domain.Movidesk.Models.Persons
{
    public class Email
    {
        public Int64? person_id { get; set; }
        public string? emailType { get; set; }
        public string? email { get; set; }
        public bool? isDefault { get; set; }

        public Email() { }

        public Email(Dtos.Persons.Email email, Int64? person_id)
        {
            this.person_id = person_id;
            emailType = email.emailType;
            this.email = email.email;
            isDefault = Convert.ToBoolean(email.isDefault);
        }
    }
}
