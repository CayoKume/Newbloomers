namespace Domain.IntegrationsCore.Entities.Errors
{
    public class Record
    {
        public string FieldKeyValue { get; private set; } = String.Empty;
        public string? RegText { get; private set; }

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
            this.RegText = regXML;
        }
    }
}
