namespace Application.WebApi.Interfaces.Services
{
    public interface ICancellationRequestService
    {
        public Task CreateCancellationRequest(string serializedOrder);
        public Task<string> GetReasons();
        public Task<string> GetOrderToCancel(string number, string serie, string doc_company);
    }
}
