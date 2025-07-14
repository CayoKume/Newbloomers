using Domain.TotalExpress.Entities;

namespace Domain.TotalExpress.Interfaces.Repository
{
    public interface ITotalExpressRepository
    {
        public Task<bool> GenerateResponseLog(string? orderNumber, string? sender_id, string? response);
        public Task<bool> GenerateRequestLog(string? orderNumber, string? request);

        public Task<Order> GetInvoicedOrder(string? orderNumber);
        public Task<List<Order>> GetInvoicedOrders();
        public Task<Parameters> GetParameters(string? docCompany, string? method);
        public Task<IEnumerable<Parameters>> GetSenderIds();
        public Task<IEnumerable<Parameters>> GetSenderAwbs();

        public Task<bool> UpdateDeliveryDates(string? deliveryMadeDate, string? collectionDate, string? deliveryForecastDate, string? lastStatusDate, string? lastStatusDescription, string? orderNumber);
    }
}
