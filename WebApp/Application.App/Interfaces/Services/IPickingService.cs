using Application.App.ViewModels.Picking;
using Domain.App.Entities;
using Order = Application.App.ViewModels.Picking.Order;

namespace Application.App.Interfaces.Services
{
    public interface IPickingService
    {
        public Task<List<ShippingCompany>?> GetShippingCompanys();
        public Task<List<Order>?> GetUnpickedOrders(string cnpj_emp, string serie_pedido, string data_inicial, string data_final);
        public Task<Order?> GetUnpickedOrder(string cnpj_emp, string serie, string nr_pedido);

        public Task PrintCoupons(Order pedido);
        public Task<string> PrintCoupon(string cnpj_emp, string serie, string nr_pedido);

        public Task<bool> UpdateRetorno(Order pedido);
        public Task<bool> UpdateShippingCompany(string nr_pedido, int cod_transportador);
    }
}
