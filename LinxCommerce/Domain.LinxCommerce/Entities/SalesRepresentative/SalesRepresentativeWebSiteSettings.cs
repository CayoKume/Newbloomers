using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeWebSiteSettings
    {
        public int? SalesRepresentativeID { get; set; }
        public string? WebSiteFilter { get; set; }
        public List<int>? WebSiteGroups { get; set; }
        public List<int>? WebSites { get; set; }

        [SkipProperty]
        public string? WebSiteGroup { get; set; }
        
        [SkipProperty]
        public string? WebSite { get; set; }

        public static bool operator ==(SalesRepresentativeWebSiteSettings a, SalesRepresentativeWebSiteSettings b)
        {
            if (a is not null && b is not null)
                return a.WebSiteFilter == b.WebSiteFilter &&
                       a.WebSiteGroups.Count() > 0 ? String.Join(", ", a.WebSiteGroups) == b.WebSiteGroup : b.WebSiteGroup == null &&
                       a.WebSites.Count() > 0 ? String.Join(", ", a.WebSites) == b.WebSite : b.WebSite == null;
            else if (a is null && b is null)
                return true;

            return false;
        }

        public static bool operator !=(SalesRepresentativeWebSiteSettings a, SalesRepresentativeWebSiteSettings b)
        {
            return !(a == b);
        }
    }
}
