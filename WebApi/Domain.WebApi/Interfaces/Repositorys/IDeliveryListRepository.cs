using Domain.WebApi.Models;

namespace Domain.WebApi.Interfaces.Repositorys
{
    public interface IDeliveryListRepository
    {
        public Task<bool?> InsertPickedsDates(Guid guid, string doc_company, string deliveryListName, string carrier, IEnumerable<Order> orders);

        public Task<DeliveryList?> GetDeliveryList(string identificador);
        public Task<IEnumerable<DeliveryList>> GetDeliveryLists(string cnpj_emp, string data_inicial, string data_final);

        public Task<IEnumerable<Order>?> GetOrdersShipped(string cod_transportadora, string cnpj_emp, string serie_pedido, string data_inicial, string data_final);
        public Task<Order?> GetOrderShipped(string nr_pedido, string serie, string cnpj_emp, string transportadora);
        
        public Task<bool?> SetColletedAtDate(string identificador);
    }
}
