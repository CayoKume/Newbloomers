using Application.Core.Middlewares;
using Application.TotalExpress.Interfaces;
using Domain.Core.Entities.Exceptions;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs.Shippment
{
    public class TotalExpress
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly ITotalExpressService _totalExpressService;

        public TotalExpress(ITotalExpressService totalExpressService, IServiceProvider services) =>
            (_totalExpressService, _webJobExceptionHandlingMiddleware) = (totalExpressService, new WebJobExceptionHandlingMiddleware(services));

        //public async Task SearchTrackingHistory([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //    {
        //        var result = await _totalExpressService.InsertLogOrdersByAWBs();
        //    });
        //}

        //public async Task SendOrders([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //    {
        //        var result = await _totalExpressService.SendOrders();
        //    });
        //}
    }
}
