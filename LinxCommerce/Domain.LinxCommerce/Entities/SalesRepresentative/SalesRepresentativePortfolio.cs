using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativePortfolio
    {
        public int? SalesRepresentativeID { get; set; }
        public bool? HasPortfolio { get; set; }
        public string? PortfolioAssociationType { get; set; }

        [SkipProperty]
        public List<SalesRepresentativeCustomerRelation>? Customers { get; set; } = new List<SalesRepresentativeCustomerRelation>();
    }
}
