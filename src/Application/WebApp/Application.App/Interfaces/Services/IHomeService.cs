using Application.App.ViewModels.Home;

namespace Application.App.Interfaces.Services
{
    public interface IHomeService
    {
        public Task<List<Order>?> GetPickupOrders(string cnpj_emp);
    }
}
