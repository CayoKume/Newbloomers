using LabelsPrinter.Application.Interfaces.Services;

namespace LabelsPrinter
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                ILabelsPrinterService _labelsPrinterService = scope.ServiceProvider.GetRequiredService<ILabelsPrinterService>();

                while (!stoppingToken.IsCancellationRequested)
                {
                    await _labelsPrinterService.PrintLabels();
                    await Task.Delay(2 * 1000, stoppingToken);
                } 
            }
        }
    }
}
