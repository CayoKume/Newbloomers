using Application.Jadlog.Interfaces;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs
{
    public class Jadlog
    {
        private readonly IJadlogService _jadlogService;

        public Jadlog(IJadlogService jadlogService)
        {
            _jadlogService = jadlogService;
        }

        //public async Task SearchTrackingHistory([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var result = await _jadlogService.SearchTrackingHistory();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
