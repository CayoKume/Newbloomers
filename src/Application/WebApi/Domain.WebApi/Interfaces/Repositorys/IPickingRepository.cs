using Domain.WebApi.Models;
using Domain.Wms.Models;

namespace Domain.WebApi.Interfaces.Repositorys
{
    public interface IPickingRepository
    {
        public Task<List<ShippingCompany>?> GetShippingCompanys();
        public Task<List<PickingOrder>?> GetUnpickedOrders(string cnpj_emp, string serie_pedido, string data_inicial, string data_final);
        public Task<PickingOrder?> GetUnpickedOrder(string cnpj_emp, string serie, string nr_pedido);
        public Task<PickingOrder?> GetUnpickedOrderToPrint(string cnpj_emp, string serie, string nr_pedido);
        public Task<List<PickingOrder>?> GetUnpickedOrdersToPrint(string cnpj_emp, string serie_pedido, string data_inicial, string data_final);
        public Task<int> UpdateRetorno(string nr_pedido, int volumes, string listProdutos);
        public Task<int> UpdateShippingCompany(string nr_pedido, int cod_transportador);
    }
}
