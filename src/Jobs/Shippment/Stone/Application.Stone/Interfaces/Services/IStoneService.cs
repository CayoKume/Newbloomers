namespace Application.Stone.Interfaces.Services
{
    public interface IStoneService
    {
        public Task<bool> GetZplLabels();
        public Task<string> GetAccessToken();
        public Task<string> GetDeliveryOptions();
        public Task<bool> CreateDeliveryOrder();
        public Task<bool> CheckDeliveryOrder();
        public Task<string> CancelOrder();
    }
}
