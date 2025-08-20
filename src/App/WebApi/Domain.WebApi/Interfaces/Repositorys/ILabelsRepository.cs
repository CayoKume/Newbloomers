using Domain.WebApi.Models;

namespace Domain.WebApi.Interfaces.Repositorys
{
    public interface ILabelsRepository
    {
        public Task<LabelsOrder> GetOrdersToPresent(string cnpj_emp, string serie, string nr_pedido);
        public Task<IEnumerable<LabelsOrder>> GetOrdersToPrint(string cnpj_emp, string serie, string data_inicial, string data_final);
        public Task<LabelsOrder> GetOrderToPrint(string cnpj_emp, string serie, string nr_pedido);
        public Task<int> UpdatePrintedFlag(string nr_pedido);
    }
}
