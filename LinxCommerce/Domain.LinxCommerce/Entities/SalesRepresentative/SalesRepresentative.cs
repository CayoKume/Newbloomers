using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
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
        public List<SalesRepresentativeAddress>? Addresses { get; set; } = new List<SalesRepresentativeAddress>();

        [SkipProperty]
        public SalesRepresentativeMaxDiscount? MaxDiscount { get; set; }

        [SkipProperty]
        public SalesRepresentativeWebSiteSettings? WebSiteSettings { get; set; }

        [SkipProperty]
        public SalesRepresentativePortfolio? Portfolio { get; set; }

        public static void Compare(List<SalesRepresentative?> salesRepresentativeAPIList, List<SalesRepresentative> salesRepresentativeDboList)
        {
            if (salesRepresentativeDboList.Count() > 0)
            {
                foreach (var sDbo in salesRepresentativeDboList)
                {
                    try
                    {
                        var sAPI = salesRepresentativeAPIList
                                    .Where(sAPI =>
                                            sAPI.SalesRepresentativeID == sDbo.SalesRepresentativeID
                                    ).FirstOrDefault();

                        salesRepresentativeAPIList.Remove(
                            salesRepresentativeAPIList
                                .Where(sAPI =>
                                    sAPI.SalesRepresentativeID == sDbo.SalesRepresentativeID &&
                                    sAPI.Name == sDbo.Name &&
                                    sAPI.FriendlyCode == sDbo.FriendlyCode &&
                                    sAPI.ImageUrl == sDbo.ImageUrl &&
                                    sAPI.IntegrationID == sDbo.IntegrationID &&
                                    sAPI.AllowQuoteDeletion == sDbo.AllowQuoteDeletion &&
                                    sAPI.BusinessContractID == sDbo.BusinessContractID &&
                                    sAPI.SalesRepresentativeType == sDbo.SalesRepresentativeType &&
                                    sAPI.Status == sDbo.Status &&

                                    sAPI.Identification == sDbo.Identification &&
                                    sAPI.Commission == sDbo.Commission &&
                                    sAPI.Contact == sDbo.Contact &&
                                    sAPI.ShippingRegion == sDbo.ShippingRegion &&

                                    sAPI.Addresses.All(x => sDbo.Addresses.Contains(x)) &&

                                    sAPI.MaxDiscount == sDbo.MaxDiscount &&
                                    sAPI.WebSiteSettings == sDbo.WebSiteSettings &&

                                    sAPI.Portfolio.HasPortfolio == sDbo.Portfolio.HasPortfolio &&
                                    sAPI.Portfolio.PortfolioAssociationType == sDbo.Portfolio.PortfolioAssociationType &&
                                    sAPI.Portfolio.Customers.All(x => sDbo.Portfolio.Customers.Contains(x))
                                ).FirstOrDefault()
                        );

                        if (sAPI.Addresses.Count() > 0 && sDbo.Addresses.Count() > 0)
                            sAPI.Addresses = SalesRepresentativeAddress.Compare(sAPI.Addresses, sDbo.Addresses);

                        if (sAPI.Portfolio != null && sDbo.Portfolio != null)
                            sAPI.Portfolio.Customers = SalesRepresentativeCustomerRelation.Compare(sAPI.Portfolio.Customers, sDbo.Portfolio.Customers);

                        sDbo.Addresses.AddRange(sAPI.Addresses);
                        sDbo.Portfolio.Customers.AddRange(sAPI.Portfolio.Customers);
                    }
                    catch (Exception ex)
                    {
                        throw new InternalException(
                            stage: EnumStages.Compare,
                            error: EnumError.Compare,
                            level: EnumMessageLevel.Error,
                            message: $"Error when comparing two lists of records",
                            exceptionMessage: ex.Message
                        );
                    }
                } 
            }
        }
    }
}
