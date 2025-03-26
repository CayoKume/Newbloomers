using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Responses;
using System.Data;

namespace Domain.LinxCommerce.Interfaces.Repositorys
{
    public interface IOrderStatusRepository
    {
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, SearchOrderStatus.Root registros);
        public Task<List<Entities.Order.Order>> GetRegistersExists(List<string> ordersIds, string? database);
        public DataTable CreateSystemDataTable<TEntity>(LinxCommerceJobParameter jobParameter, TEntity entity);
    }
}
