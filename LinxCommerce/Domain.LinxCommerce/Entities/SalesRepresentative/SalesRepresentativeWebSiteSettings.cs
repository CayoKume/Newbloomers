namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeWebSiteSettings
    {
        public int? SalesRepresentativeID { get; set; }
        public string? WebSiteFilter { get; set; }
        public List<int>? WebSiteGroups { get; set; }
        public List<int>? WebSites { get; set; }
    }
}
