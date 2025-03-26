using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Responses;

namespace Domain.LinxCommerce.Interfaces.Repositorys
{
    public interface IOrderRepository
    {
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Entities.Order.Order.Root> registros, Guid? parentExecutionGUID);
        public Task<List<Entities.Order.Order.Root>> GetRegistersExists(IEnumerable<Guid?> guids);
    }
}
