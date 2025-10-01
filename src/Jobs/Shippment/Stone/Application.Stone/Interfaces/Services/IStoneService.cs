namespace Application.Stone.Interfaces.Services
{
    public interface IStoneService
    {
        public Task<string> GetAccessToken();
        public Task<string> GetDeliveryOptions();
        public Task<string> CreateDeliveryOrder();
        public Task<bool> CheckDeliveryOrder();
        public Task<string> CancelOrder();
    }
}
