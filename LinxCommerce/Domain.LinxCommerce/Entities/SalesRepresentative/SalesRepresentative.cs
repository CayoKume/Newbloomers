using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentative
    {
        public int? SalesRepresentativeID { get; set; }
        public string? Name { get; set; }
        public string? FriendlyCode { get; set; }
        public string? ImageUrl { get; set; }
        public string? IntegrationID { get; set; }
        public bool? AllowQuoteDeletion { get; set; }
        public int? BusinessContractID { get; set; }
        public string? SalesRepresentativeType { get; set; }
        public string? Status { get; set; }

        [SkipProperty]
        public Dictionary<int, string> Responses { get; set; } = new Dictionary<int, string>();

        [SkipProperty]
        public SalesRepresentativeIdentification? Identification { get; set; }

        [SkipProperty]
        public SalesRepresentativeComission? Commission { get; set; }

        [SkipProperty]
        public SalesRepresentativeContactData? Contact { get; set; }

        [SkipProperty]
        public SalesRepresentativeShippingRegion? ShippingRegion { get; set; }

        [SkipProperty]
        public List<SalesRepresentativeAddress> Addresses { get; set; } = new List<SalesRepresentativeAddress>();

        [SkipProperty]
        public SalesRepresentativeMaxDiscount? MaxDiscount { get; set; }

        [SkipProperty]
        public SalesRepresentativeWebSiteSettings? WebSiteSettings { get; set; }

        [SkipProperty]
        public SalesRepresentativePortfolio? Portfolio { get; set; }
    }
}
