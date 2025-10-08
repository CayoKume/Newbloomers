using Order = LabelsPrinter.Domain.Entities.Order;
using LabelsPrinter.Domain.Interfaces;
using Domain.Core.Interfaces;
using LabelsPrinter.Application.Interfaces.Handlers.Commands;

namespace LabelsPrinter.Infrastructure.Repositorys
{

    public class LabelsPrinterRepository : ILabelsPrinterRepository
    {
        private readonly ICoreRepository _conn;
        private readonly ILabelsPrinterCommandHandler _labelsPrinterCommandHandler;

        public LabelsPrinterRepository(ICoreRepository conn, ILabelsPrinterCommandHandler labelsPrinterCommandHandler) =>
            (_conn, _labelsPrinterCommandHandler) = (conn, labelsPrinterCommandHandler);

        public async Task<IEnumerable<Order>> GetOrders()
        {
            string sql = _labelsPrinterCommandHandler.CreateGetOrdersQuery();
            return await _conn.GetRecords<Order>(sql);
        }

        public async Task<bool> UpdateStatus(Int64 idcontrole)
        {
            string sql = _labelsPrinterCommandHandler.CreateUpdateStatusQuery(idcontrole);
            return await _conn.ExecuteCommand(sql);
        }
    }
}
