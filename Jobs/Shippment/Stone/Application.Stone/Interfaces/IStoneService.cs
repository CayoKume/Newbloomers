namespace Application.Stone.Interfaces
{
    public interface IStoneService
    {
        public Task<string> GetAccessToken();
        public Task<string> GetDeliveryOptions();
        public Task<string> CreateDeliveryOrder();
        public Task<string> CheckDeliveryOrder();
        public Task<string> CancelOrder();
    }
}
