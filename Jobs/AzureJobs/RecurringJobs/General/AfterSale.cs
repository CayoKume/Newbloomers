using Application.AfterSale.Interfaces;
using Application.Core.Middlewares;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs.General
{
    public class AfterSale
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly IAfterSaleService _afterSaleService;

        public AfterSale(IAfterSaleService afterSaleService, IServiceProvider services) =>
            (_afterSaleService, _webJobExceptionHandlingMiddleware) = (afterSaleService, new WebJobExceptionHandlingMiddleware(services));

        //public async Task AfterSaleEcommerces([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //    {
        //        var result = await _afterSaleService.GetMe();
        //    });
        //}

        //public async Task AfterSaleTransportations([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //    {
        //        var result = await _afterSaleService.GetReversesTransportations();
        //    });
        //}

        //public async Task AfterSaleStatus([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //    {
        //        var result = await _afterSaleService.GetReversesStatus();
        //    });
        //}

        //public async Task AfterSaleReverses([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //    {
        //        var result = await _afterSaleService.GetReverses();
        //    });
        //}
    }
}
