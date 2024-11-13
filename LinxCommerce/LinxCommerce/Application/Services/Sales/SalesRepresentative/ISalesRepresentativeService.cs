namespace LinxCommerce.Application.Services.Sales.SalesRepresentative
{
    public interface ISalesRepresentativeService
    {
        public Task<string?> DeleteSalesRepresentative(Int32 salesRepresentativeId);
        public Task<string?> GetSalesRepresentative();
        public Task<string?> SaveSalesRepresentative();
        public Task<string?> SearchSalesRepresentative();
    }
}
