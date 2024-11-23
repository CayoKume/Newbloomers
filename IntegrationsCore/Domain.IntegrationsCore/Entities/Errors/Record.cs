namespace Domain.IntegrationsCore.Entities.Errors
{
    public class Record
    {
        public string FieldKeyValue { get; private set; } = String.Empty;
        public string? RegText { get; private set; }

        public Record() { }

        public Record(
            string key,
            string? regXML
        )
        {
            this.FieldKeyValue = key;
            this.RegText = regXML;
        }
    }
}
