using Domain.LinxCommerce.Entities.Parameters;

namespace Application.LinxCommerce.Interfaces
{
    public interface ISalesRepresentativeService
    {
        public Task<string?> DeleteSalesRepresentative(int salesRepresentativeId);
        public Task<string?> GetSalesRepresentative(LinxCommerceJobParameter jobParameter, int? salesRepresentativeId);
        public Task<string?> SaveSalesRepresentative();
        public Task<string?> SearchSalesRepresentative(LinxCommerceJobParameter jobParameter);
    }
}
