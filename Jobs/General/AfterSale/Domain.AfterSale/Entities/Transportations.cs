using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using Ubiety.Dns.Core.Records;

namespace Domain.AfterSale.Entities
{
    public class Transportations
    {
        /// <summary>
        /// auto increment property created to be the primary key of the migration
        /// </summary>
        [SkipProperty]
        public int? id { get; set; }

        public string? description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        [SkipProperty]
        public string? RecordKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        [SkipProperty]
        public List<string> data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [SkipProperty]
        [NotMapped]
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
