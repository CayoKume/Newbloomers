namespace Domain.IntegrationsCore.Entities
{
    public class Job
    {
        public int? IdParent { get; set; }
        public int? IdJob { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? IdType { get; set; }
        public string? Info { get; set; }
        public string? EnumJobName { get; set; }
    }
}
