namespace Application.TotalExpress.Interfaces
{
    public interface ITotalExpressService
    {
        public Task<bool> SendOrders();
        public Task<bool> SendOrder(string? orderNumber);
        public Task<bool> SendOrderAsEtur(string? orderNumber);
        public Task<bool> UpdateLogOrders();
    }
}
