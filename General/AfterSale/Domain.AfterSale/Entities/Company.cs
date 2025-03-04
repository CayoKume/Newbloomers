using Domain.IntegrationsCore.Entities.Bases;

namespace Domain.AfterSale.Entites.Company
{
    public class Company : CompanyBase
    {
        public Guid? Token { get; set; }
    }
}
