using Application.WebApp.ViewModels.ExecuteCancellation;

namespace Application.WebApp.Interfaces.Services
{
    public interface IExecuteCancellationService
    {
        public Task<Dictionary<int, string>> GetReasons();
        public Task<List<Order>> GetOrdersToCancel(string serie, string doc_company);
        public Task<bool> UpdateDateCanceled(string number, string suporte, string inputObs, int motivo);
    }
}
