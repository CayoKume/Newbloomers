using System.Collections.Generic;

namespace Domain.Movidesk.Models.Tickets
{
    public class CustomFieldValue
    {
        public int customFieldId { get; set; }
        public int customFieldRuleId { get; set; }
        public int line { get; set; }
        public string? value { get; set; }

        public List<CustomFieldItem> items { get; set; }
    }
}