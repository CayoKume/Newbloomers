using Domain.Core.Entities.Base;

namespace Domain.AfterSale.Models
{
    public class Company : CompanyBase
    {
        public Guid? Token { get; set; }
    }
}
