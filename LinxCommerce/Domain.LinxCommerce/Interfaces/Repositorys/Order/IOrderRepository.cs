using Domain.LinxCommerce.Entities.Parameters;
using System.Data;

namespace Domain.LinxCommerce.Interfaces.Repositorys.Order
{
    public interface IOrderRepository
    {
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Domain.LinxCommerce.Entities.Order.Order> registros, string? database);
        public Task<List<Domain.LinxCommerce.Entities.Order.Order>> GetRegistersExists(List<string> ordersIds);
        public DataTable CreateSystemDataTable<TEntity>(LinxCommerceJobParameter jobParameter, TEntity entity);
    }
}
