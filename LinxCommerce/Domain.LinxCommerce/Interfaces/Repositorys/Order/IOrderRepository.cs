using Domain.LinxCommerce.Entities.Parameters;
using System.Data;

namespace Domain.LinxCommerce.Interfaces.Repositorys.Order
{
    public interface IOrderRepository
    {
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Domain.LinxCommerce.Entities.Order.Order.Root> registros);
        public Task<List<Domain.LinxCommerce.Entities.Order.Order.Root>> GetRegistersExists(List<string> guids);
    }
}
