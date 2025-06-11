namespace Domain.Movidesk.Entities
{
    public class Person
    {
        public string? id { get; set; }
        public string? codeReferenceAdditional { get; set; }
        public bool? isActive { get; set; }
        public Int32? personType { get; set; }
        public Int32? profileType { get; set; }
        public string? accessProfile { get; set; }
        public string? businessName { get; set; }
        public string? businessBranch { get; set; }
        public string? corporateName { get; set; }
        public string? cpfCnpj { get; set; }
        public string? userName { get; set; }
        public string? accountEmail { get; set; }
        public string? role { get; set; }
        public string? bossId { get; set; }
        public string? bossName { get; set; }
        public string? classification { get; set; }
        public string? cultureId { get; set; }
        public string? timeZoneId { get; set; }
        public DateTime? createdDate { get; set; }
        public string? createdBy { get; set; }
        public DateTime? changedDate { get; set; }
        public string? changedBy { get; set; }
        public string? observations { get; set; }
        public string? authenticateOn { get; set; }
        public List<Address>? addresses { get; set; }
        public List<Contact>? contacts { get; set; }
        public List<Email>? emails { get; set; }
        public List<string>? teams { get; set; }
        public List<Relationship>? relationships { get; set; }
        public List<CustomFieldValue>? customFieldValues { get; set; }
    }
}
