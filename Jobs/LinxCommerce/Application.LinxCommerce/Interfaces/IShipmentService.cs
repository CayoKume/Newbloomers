namespace Application.LinxCommerce.Interfaces
{
    public interface IShipmentService
    {
        public Task<string?> GetShipment();
        public Task<string?> SearchShipments();
        public Task<string?> UpdateShipment();
    }
}
