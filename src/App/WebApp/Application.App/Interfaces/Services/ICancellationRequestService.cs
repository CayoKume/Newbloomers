using Application.WebApp.ViewModels.CancellationRequest;

namespace Application.WebApp.Interfaces.Services
{
    public interface ICancellationRequestService
    {
        public Task<bool> CreateCancellationRequest(Order order);
        public Task<Dictionary<int, string>> GetReasons();
        public Task<Order> GetOrderToCancel(string number, string serie, string doc_company);
    }
}
