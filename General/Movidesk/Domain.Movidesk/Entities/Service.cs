namespace Domain.Movidesk.Entities
{
    public class Service
    {
        public Int32? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public Int32? parentServiceId { get; set; }
        public Int32? serviceForTicketType { get; set; }
        public Int32? isVisible { get; set; }
        public Int32? allowSelection { get; set; }
        public bool? allowFinishTicket { get; set; }
        public bool? isActive { get; set; }
        public bool? copyToChildren { get; set; }
        public string? automationMacro { get; set; }
        public string? defaultCategory { get; set; }
        public string? defaultUrgency { get; set; }
        public bool? allowAllCategories { get; set; }
        public List<string>? categories { get; set; }
    }
}
