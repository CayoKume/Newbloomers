using Domain.LinxCommerce.Entities.Order;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Responses;

namespace Domain.LinxCommerce.Interfaces.Repositorys
{
    public interface IOrderRepository
    {
        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Order.Root> registros, Guid? parentExecutionGUID);
        public bool BulkInsertIntoUpdateTrackingNumberOrderTable(LinxCommerceJobParameter jobParameter, List<OrderTrackingNumber> registros);
        public Task<bool> InsertIntoUpdateTrackingNumberOrderTable(LinxCommerceJobParameter jobParameter, OrderTrackingNumber registro);
        public Task<List<Entities.Order.Order.Root>> GetRegistersExists(IEnumerable<Guid?> guids);
        public Task<List<OrderTrackingNumber>> GetTrackingNumbersToUpdate();
    }
}
