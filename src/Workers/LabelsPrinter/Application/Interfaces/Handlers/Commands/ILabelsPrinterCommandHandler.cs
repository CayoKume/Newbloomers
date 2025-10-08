using LabelsPrinter.Domain.Entities;

namespace LabelsPrinter.Application.Interfaces.Handlers.Commands
{
    public interface ILabelsPrinterCommandHandler
    {
        string CreateGetOrdersQuery();
        string CreateUpdateStatusQuery(Int64 idcontrole);
    }
}
