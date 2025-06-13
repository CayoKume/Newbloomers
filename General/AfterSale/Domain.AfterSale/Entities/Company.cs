using Domain.IntegrationsCore.Models.Bases;

namespace Domain.AfterSale.Entities
{
    public class Company : CompanyBase
    {
        public Guid? Token { get; set; }
    }
}
