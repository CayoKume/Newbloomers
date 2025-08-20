using Domain.Core.Interfaces;
using Microsoft.Azure.WebJobs;
using System.Data;

namespace AzureJobs.RecurringJobs.Procedures
{
    public class Dbo
    {
        private readonly ICoreRepository _coreRepository;

        public Dbo(ICoreRepository coreRepository) =>
            _coreRepository = coreRepository;

        //public Task P_Server_Maintenance([TimerTrigger("0 0 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    Task.Run(async () =>
        //    {
        //        await _coreRepository.ExecuteCommand("exec [dbo].[P_Server_Maintenance]");
        //    });

        //    return Task.CompletedTask;
        //}
    }
}
