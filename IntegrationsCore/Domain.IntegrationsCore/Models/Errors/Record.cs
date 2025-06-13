namespace Domain.IntegrationsCore.Models.Errors
{
    public class Record
    {
        public string FieldKeyValue { get; private set; } = String.Empty;
        public string? RecordText { get; private set; }
        public Guid Execution { get; private set; }

        public Record() { }

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <param name="key"></param>
        /// <param name="regXML"></param>
        public Record(
            string key,
            string? regXML
        )
        {
            this.FieldKeyValue = key;
            this.RecordText = regXML;
        }
    }
}
