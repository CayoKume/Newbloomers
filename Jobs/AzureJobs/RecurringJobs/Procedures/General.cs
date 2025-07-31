using Application.Core.Middlewares;
using Domain.Core.Interfaces;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs.Procedures
{
    internal class General
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly ICoreRepository _coreRepository;

        public General(ICoreRepository coreRepository) =>
            _coreRepository = coreRepository;

        //public async Task P_Volo_Integracao_Pedidos([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Pedidos]");

        //    return;
        //}

        //public async Task P_Server_Maintenance([TimerTrigger("0 0 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [dbo].[P_Server_Maintenance]");

        //    return;
        //}
    }
}
