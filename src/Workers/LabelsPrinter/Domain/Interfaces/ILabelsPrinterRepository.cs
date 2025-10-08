using LabelsPrinter.Domain.Entities;

namespace LabelsPrinter.Domain.Interfaces
{
    public interface ILabelsPrinterRepository
    {
        public Task<IEnumerable<Order>> GetOrders();
        public Task<bool> UpdateStatus(Int64 idcontrole);
    }
}
