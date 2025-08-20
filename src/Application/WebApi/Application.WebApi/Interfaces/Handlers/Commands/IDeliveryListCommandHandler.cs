using Domain.WebApi.Models;

namespace Application.WebApi.Interfaces.Handlers.Commands
{
    public interface IDeliveryListCommandHandler
    {
        string CreateInsertPickedsDatesQuery(Guid guid, string deliveryListName, string carrier, IEnumerable<Order> orders);
        string CreateGetOrdersShippedQuery(string cod_transportadora, string cnpj_emp, string serie_pedido, string data_inicial, string data_final);
        string CreateGetOrderShippedQuery(string nr_pedido, string serie, string cnpj_emp, string transportadora);
        string CreateGetDeliveryListQuery(string identificador);
        string CreateGetDeliveryListsQuery(string cnpj_emp, string data_inicial, string data_final);
    }
}
