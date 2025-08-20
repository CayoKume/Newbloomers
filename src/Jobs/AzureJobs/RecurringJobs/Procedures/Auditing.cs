using Domain.Core.Interfaces;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs.Procedures
{
    public class Auditing
    {
        private readonly ICoreRepository _coreRepository;

        public Auditing(ICoreRepository coreRepository) =>
            _coreRepository = coreRepository;

        //public Task P_Delete_Auditing_Logs([TimerTrigger("0 6 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    Task.Run(async () =>
        //    {
        //        await _coreRepository.ExecuteCommand("exec [dbo].[p_Delete_Auditing_Logs]");
        //    });

        //    return Task.CompletedTask;
        //}
    }
}
