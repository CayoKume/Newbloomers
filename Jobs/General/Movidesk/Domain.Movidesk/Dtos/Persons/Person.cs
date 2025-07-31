namespace Domain.Movidesk.Dtos.Persons
{
    public class Person
    {
        public string? id { get; set; }
        public string? codeReferenceAdditional { get; set; }
        public string? isActive { get; set; }
        public string? personType { get; set; }
        public string? profileType { get; set; }
        public string? accessProfile { get; set; }
        public string? businessName { get; set; }
        public string? corporateName { get; set; }
        public string? cpfCnpj { get; set; }
        public string? userName { get; set; }
        public string? role { get; set; }
        public string? bossId { get; set; }
        public string? classification { get; set; }
        public string? cultureId { get; set; }
        public string? timeZoneId { get; set; }
        public string createdDate { get; set; }
        public string? observations { get; set; }
        public List<Address>? addresses { get; set; }
        public List<Contact>? contacts { get; set; }
        public List<Email>? emails { get; set; }
        public List<Relationship>? relationships { get; set; }
    }
}
