namespace Domain.Movidesk.Entities
{
    public class PersonTicket
    {
        public string? id { get; set; }
        public Int32? personType { get; set; }
        public Int32? profileType { get; set; }
        public string? businessName { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public string? complement { get; set; }
        public string? cep { get; set; }
        public string? city { get; set; }
        public string? bairro { get; set; }
        public string? number { get; set; }
        public string? reference { get; set; }
        public bool? isDeleted { get; set; }
        public PersonTicket? organization { get; set; }
    }
}
