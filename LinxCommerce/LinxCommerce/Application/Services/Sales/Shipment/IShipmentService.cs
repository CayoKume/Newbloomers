namespace LinxCommerce.Application.Services.Sales.Shipment
{
    public interface IShipmentService
    {
        public Task<string?> GetShipment();
        public Task<string?> SearchShipments();
        public Task<string?> UpdateShipment();
    }
}
