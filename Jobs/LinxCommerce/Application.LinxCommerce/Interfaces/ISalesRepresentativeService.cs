using Domain.LinxCommerce.Entities.Parameters;

namespace Application.LinxCommerce.Interfaces
{
    public interface ISalesRepresentativeService
    {
        public Task<bool?> DeleteSalesRepresentative(int salesRepresentativeId);
        public Task<bool?> GetSalesRepresentative(LinxCommerceJobParameter jobParameter, int? salesRepresentativeId);
        public Task<bool?> SaveSalesRepresentative();
        public Task<bool?> SearchSalesRepresentative(LinxCommerceJobParameter jobParameter);
    }
}
