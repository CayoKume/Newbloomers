using Domain.IntegrationsCore.Extensions;

namespace Domain.AfterSale.Entities
{
    public class Transportations
    {
        public string? description { get; set; }

        [SkipProperty]
        public List<string> data { get; set; }
    }
}
