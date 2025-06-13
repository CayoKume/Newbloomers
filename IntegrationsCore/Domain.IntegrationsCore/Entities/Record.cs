namespace Domain.IntegrationsCore.Entities
{
    public class Record
    {
        public int? IdRecord { get; set; }
        public string? FieldKeyValue { get; set; }
        public string? RecordText { get; set; }
        public Guid? Execution { get; set; }
    }
}
