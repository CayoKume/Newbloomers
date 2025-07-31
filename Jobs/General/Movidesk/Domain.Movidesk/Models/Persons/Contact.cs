namespace Domain.Movidesk.Models.Persons
{
    public class Contact
    {
        public Int64 person_id { get; set; }
        public string? contactType { get; set; }
        public string? contact { get; set; }
        public bool? isDefault { get; set; }

        public Contact() { }

        public Contact(Dtos.Persons.Contact contact, Int64 person_id)
        {
            this.person_id = person_id;
            contactType = contact.contactType;
            this.contact = contact.contact;
            isDefault = Convert.ToBoolean(contact.isDefault);
        }
    }
}
