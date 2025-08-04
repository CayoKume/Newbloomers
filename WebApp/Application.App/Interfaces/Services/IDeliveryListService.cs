using Application.App.ViewModels.DeliveryList;
using DeliveryList = Domain.App.Entities.DeliveryList;

namespace Application.App.Interfaces.Services
{
    public interface IDeliveryListService
    {
        public Task<List<Order>?> GetOrdersShipped(string cod_transportadora, string cnpj_emp, string serie_pedido, string data_inicial, string data_final);
        public Task<Order?> GetOrderShipped(string nr_pedido, string serie, string cnpj_emp, string transportadora);

        public Task<DeliveryList?> GetDeliveryList(string identificador);
        public Task<List<DeliveryList>?> GetDeliveryLists(string cnpj_emp, DateTime? data_inicial, DateTime? data_final);

        public Task<string> GetDeliveryListToPrint(string fileName);

        public Task SetColletedAtDate(DeliveryList deliveryList);

        public Task PrintOrder(List<Order> pedidos);
    }
}
