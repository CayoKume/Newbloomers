namespace Domain.Movidesk.Entities
{
    public class Relationship
    {
        public Int32? id { get; set; }
        public string? name { get; set; }
        public string? slaAgreement { get; set; }
        public bool? forceChildrenToHaveSomeAgreement { get; set; }
        public bool? allowAllServices { get; set; }
        public bool? includeInParents { get; set; }
        public bool? loadChildOrganizations { get; set; }
        public bool? isGetMethod { get; set; }
        public List<Service>? services { get; set; }
    }
}
