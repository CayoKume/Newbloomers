using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using Ubiety.Dns.Core.Records;

namespace Domain.AfterSale.Models
{
    public class Transportations
    {
        public string? description { get; set; }

        [SkipProperty]
        public string? RecordKey { get; set; }

        [SkipProperty]
        public List<string> data { get; set; }

        [SkipProperty]
        public Dictionary<string?, string> Responses { get; set; } = new Dictionary<string?, string>();

        public Transportations() { }

        public Transportations(string transportation, string recordKey, string json)
        {
            description = transportation;
            RecordKey = recordKey;
            Responses.Add(recordKey, json);
        }
    }
}
