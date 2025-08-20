using Application.WebApp.ViewModels.Home;

namespace Application.WebApp.Interfaces.Services
{
    public interface IHomeService
    {
        public Task<List<Order>?> GetPickupOrders(string cnpj_emp);
    }
}
