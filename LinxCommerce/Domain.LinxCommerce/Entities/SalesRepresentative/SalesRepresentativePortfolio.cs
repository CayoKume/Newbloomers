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

        public static bool operator ==(SalesRepresentativePortfolio a, SalesRepresentativePortfolio b)
        {
            if (a is not null && b is not null)
                return a.HasPortfolio == b.HasPortfolio && a.PortfolioAssociationType == b.PortfolioAssociationType && a.Customers.SequenceEqual(b.Customers);
            else if (a is null && b is null)
                return true;

            return false;
        }

        public static bool operator !=(SalesRepresentativePortfolio a, SalesRepresentativePortfolio b)
        {
            return !(a == b);
        }
    }
}
