using LabelsPrinter.Application.Interfaces.Services;
using LabelsPrinter.Domain.Interfaces;
using LabelsPrinter.Infrastructure.PrinterHelpers;

namespace LabelsPrinter.Application.Services
{
    public class LabelsPrinterService : ILabelsPrinterService
    {
        private readonly ILabelsPrinterRepository _labelsPrinterRepository;
        
        public LabelsPrinterService(ILabelsPrinterRepository labelsPrinterRepository)
            => (_labelsPrinterRepository) = (labelsPrinterRepository);

        public async Task PrintLabels()
        {
            var listOrders = await _labelsPrinterRepository.GetOrders();

            if (listOrders.Count() > 0)
            {
                foreach (var order in listOrders)
                {
                    try
                    {
                        //RawPrinterHelper.SendStringToPrinter("EtiquetasMicrovix", zpl);

                        await _labelsPrinterRepository.UpdateStatus(order.idcontrole);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }
    }
}
