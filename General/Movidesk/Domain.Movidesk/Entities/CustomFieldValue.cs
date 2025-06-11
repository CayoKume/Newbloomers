namespace Domain.Movidesk.Entities
{
    public class CustomFieldValue
    {
        public Int32? customFieldId { get; set; }
        public Int32? customFieldRuleId { get; set; }
        public Int32? line { get; set; }
        public string? value { get; set; }
        public List<CustomFieldItem>? items { get; set; }
    }
}
