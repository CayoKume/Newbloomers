namespace Domain.Movidesk.Dtos.Tickets
{
    public class Customfieldvalue
    {
        public string? customFieldId { get; set; }
        public string? customFieldRuleId { get; set; }
        public string? line { get; set; }
        public string? value { get; set; }
        public Item[]? items { get; set; }
    }
}
