namespace Domain.IntegrationsCore.Entities
{
    public class Error
    {
        public int? IdError { get; set; }
        public string? _Error { get; set; }
        public string? Resolution { get; set; }
        public bool? RequireUserAction { get; set; }
        public int? EmergencyLevel { get; set; }
        public string? ActionInf { get; set; }
        public string? EnumErrorName { get; set; }
    }
}
