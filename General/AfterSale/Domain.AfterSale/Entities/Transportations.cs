using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.AfterSale.Entities
{
    public class Transportations
    {
        public int? id { get; set; }
        public string? description { get; set; }

        [NotMapped]
        [SkipProperty]
        public List<string> data { get; set; }
    }
}
