namespace Domain.LinxCommerce.Entities.Sales.SalesRepresentative
{
    public class SalesRepresentativeWebSiteSettings
    {
        public string? WebSiteFilter { get; set; }
        public List<int> WebSiteGroups { get; set; } //list de int
        public List<int> WebSites { get; set; } //list de int
    }
}
