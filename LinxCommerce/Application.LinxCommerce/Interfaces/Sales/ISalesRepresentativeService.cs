namespace Application.LinxCommerce.Interfaces.Sales
{
    public interface ISalesRepresentativeService
    {
        public Task<string?> DeleteSalesRepresentative(int salesRepresentativeId);
        public Task<string?> GetSalesRepresentative();
        public Task<string?> SaveSalesRepresentative();
        public Task<string?> SearchSalesRepresentative();
    }
}
