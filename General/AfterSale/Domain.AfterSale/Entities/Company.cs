using Domain.IntegrationsCore.Entities.Bases;

namespace Domain.AfterSale.Entities
{
    public class Company : CompanyBase
    {
        public Guid? Token { get; set; }
    }
}
