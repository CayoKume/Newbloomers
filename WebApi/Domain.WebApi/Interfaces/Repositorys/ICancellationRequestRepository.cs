using Domain.WebApi.Models;

namespace Domain.WebApi.Interfaces.Repositorys
{
    public interface ICancellationRequestRepository
    {
        public Task<bool> CreateCancellationRequest(CancellationRequestOrder order);
        public Task<Dictionary<int, string>> GetReasons();
        public Task<CancellationRequestOrder> GetOrderToCancel(string number, string serie, string doc_company);
    }
}
