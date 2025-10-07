using Application.Core.Middlewares;
using Application.Stone.Interfaces.Services;
using Microsoft.Azure.WebJobs;

namespace WebJob.RecurringJobs.Shippment
{
    public class Stone
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly IStoneService _stoneService;

        public Stone(IStoneService stoneService, IServiceProvider services)
        {
            _stoneService = stoneService;
            _webJobExceptionHandlingMiddleware = new WebJobExceptionHandlingMiddleware(services);
        }

        //public async Task SearchTrackingHistory([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //    {
        //        var result = await _stoneService.CheckDeliveryOrder();
        //    });
        //}

        //public async Task SearchZplLabel([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //    {
        //        var result = await _stoneService.GetZplLabels();
        //    });
        //}
    }
}
