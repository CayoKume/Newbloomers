namespace LinxCommerce.Domain.Entities.Sales.SalesRepresentative.Requests
{
    public class SaveSalesRepresentativePhotoRequest
    {
        public string? Base64Content { get; set; }
        public string? ContentType { get; set; }
    }
}
