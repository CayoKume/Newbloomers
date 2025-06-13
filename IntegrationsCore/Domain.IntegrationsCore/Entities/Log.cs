namespace Domain.IntegrationsCore.Entities
{
    public class Log
    {
        public int? IdJob { get; set; }
        public Guid? IdExecution { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? Execution { get; set; }
        public Guid? ExecutionParent { get; set; }
    }
}
