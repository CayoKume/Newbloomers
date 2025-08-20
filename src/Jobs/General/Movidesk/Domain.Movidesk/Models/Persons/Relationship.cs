namespace Domain.Movidesk.Models.Persons
{
    public class Relationship
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? slaAgreement { get; set; }
        public bool? forceChildrenToHaveSomeAgreement { get; set; }
        public bool? allowAllServices { get; set; }
        public bool? isGetMethod { get; set; }
        public Int64? person_id { get; set; }

        public Relationship() { }

        public Relationship(Dtos.Persons.Relationship relationship, Int64? person_id)
        {
            id = Convert.ToInt32(relationship.id);
            name = relationship.name;
            slaAgreement = relationship.slaAgreement;
            forceChildrenToHaveSomeAgreement = Convert.ToBoolean(relationship.forceChildrenToHaveSomeAgreement);
            allowAllServices = Convert.ToBoolean(relationship.allowAllServices);
            isGetMethod = Convert.ToBoolean(relationship.isGetMethod);
            this.person_id = person_id;
        }
    }
}
