namespace Domain.IntegrationsCore.Entities
{
    public class Message
    {
        public int? IdExecutionMessage { get; set; }
        public int? IdStage { get; set; }
        public int? IdLogLevel { get; set; }
        public bool? IsError { get; set; }
        public int? IdError { get; set; }
        public Guid? Execution { get; set; }
        public string? Msg { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? CommandSQL { get; set; }
    }
}
