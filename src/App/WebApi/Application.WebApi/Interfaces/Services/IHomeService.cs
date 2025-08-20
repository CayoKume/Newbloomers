namespace Application.WebApi.Interfaces.Services
{
    public interface IHomeService
    {
        public Task<string> GetPickupOrders(string doc_company);
    }
}
