using Domain.Core.Entities.Base;

namespace Domain.AfterSale.Entities
{
    public class Company : CompanyBase
    {
        public Guid? Token { get; set; }
    }
}
