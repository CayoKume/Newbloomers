using Application.Core.Middlewares;
using Application.Jadlog.Interfaces;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs.Shippment
{
    public class Jadlog
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly IJadlogService _jadlogService;

        public Jadlog(IJadlogService jadlogService, IServiceProvider services)
        {
            _jadlogService = jadlogService;
            _webJobExceptionHandlingMiddleware = new WebJobExceptionHandlingMiddleware(services);
        }

        //public async Task SearchTrackingHistory([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //    {
        //        var result = await _jadlogService.SearchTrackingHistory();
        //    });
        //}
    }
}
