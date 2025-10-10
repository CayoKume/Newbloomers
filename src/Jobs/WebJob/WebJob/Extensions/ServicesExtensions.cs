using Infrastructure.AfterSale.DependencyInjection;
using Infrastructure.FlashCourier.DependencyInjection;
using Infrastructure.Core.DependencyInjection;
using Infrastructure.Jadlog.DependencyInjection;
using Infrastructure.LinxCommerce.DependencyInjection;
using Infrastructure.LinxMicrovix.Outbound.WebService.DependencyInjection;
using Infrastructure.TotalExpress.DependencyInjection;
using Infrastructure.Stone;
using Infrastructure.Dootax;

namespace AzureJobs.Extensions
{
    public static class ServicesExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScopedCoreServices();

                services.AddScopedLinxCommerceServices();
                services.AddScopedLinxMicrovixServices();
                services.AddScopedB2CLinxMicrovixServices();
                services.AddScopedFlashCourierServices();
                services.AddScopedTotalExpressServices();
                services.AddScopedJadlogServices();
                services.AddScopedAfterSaleServices();
                services.AddScopedDootaxServices();
                services.AddScopedStoneServices();
            });

            return builder;
        }
    }
}
