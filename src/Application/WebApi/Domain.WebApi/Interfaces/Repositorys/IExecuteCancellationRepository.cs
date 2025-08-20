using Domain.Wms.Models;

namespace Domain.WebApi.Interfaces.Repositorys
{
    public interface IExecuteCancellationRepository
    {
        public Task<Dictionary<int, string>> GetReasons();
        public Task<IEnumerable<ExecuteCancellationOrder>> GetOrdersToCancel(string serie, string doc_company);
        public Task<bool> UpdateDateCanceled(string number, string suporte, string inputObs, int motivo);
    }
}
