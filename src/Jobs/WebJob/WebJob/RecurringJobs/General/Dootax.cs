using Application.Core.Middlewares;
using Application.Dootax.Interfaces.Services;
using Microsoft.Azure.WebJobs;

namespace WebJob.RecurringJobs.General
{
    public class Dootax
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly IDootaxService _dootaxService;

        public Dootax(IDootaxService dootaxService, IServiceProvider services) =>
            (_dootaxService, _webJobExceptionHandlingMiddleware) = (dootaxService, new WebJobExceptionHandlingMiddleware(services));

        //public async Task DootaxSendOrders([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //    {
        //        var result = await _dootaxService.ImportFilesUpload();
        //    });
        //}
    }
}
