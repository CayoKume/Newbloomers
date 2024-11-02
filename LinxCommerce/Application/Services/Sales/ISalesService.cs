using IntegrationsCore.Domain.Entities;
using IntegrationsCore.Domain.Entities.Parameters;

namespace LinxCommerce.Application.Services.Sales
{
    public interface ISalesService
    {
        public Task<string?> DeleteSalesRepresentative(Int32 salesRepresentativeId);

        public Task<bool?> GetOrder(LinxCommerceJobParameter jobParameter, string? orderId);
        public Task<string?> GetOrderByNumber();
        public Task<string?> GetOrderGroup();
        public Task<string?> GetOrderGroupByNumber();
        public Task<string?> GetOrderPackage();
        public Task<string?> GetOrderPayment();
        public Task<string?> GetOrderPayments();
        public Task<string?> GetOrderStatus();
        public Task<string?> GetPaymentTerm();
        public Task<string?> GetQueueOrders();
        public Task<string?> GetSalesRepresentative();
        public Task<string?> GetShipment();

        public Task<string?> MakeOrderTransition();
        public Task<string?> RunOrderWorkflow();

        public Task<string?> SaveOrderItemSerialKey();
        public Task<string?> SaveOrderPackage();
        public Task<string?> SaveSalesRepresentative();

        public Task<string?> SearchFinancialOrderInfo();
        public Task<string?> SearchOrderPackage();
        public Task<string?> SearchOrders();
        public Task<string?> SearchOrdersBySeller();
        public Task<string?> SearchOrdersCandidates();
        public Task<string?> SearchOrderStatus();
        public Task<string?> SearchPaymentTerm();
        public Task<string?> SearchSalesRepresentative();
        public Task<string?> SearchShipments();

        public Task<string?> UpdateOrderInvoice();
        public Task<string?> UpdateOrder();
        public Task<string?> UpdateOrderPackageTrackingNumber();
        public Task<string?> UpdateRemarks();
        public Task<string?> UpdateShipment();
    }
}
