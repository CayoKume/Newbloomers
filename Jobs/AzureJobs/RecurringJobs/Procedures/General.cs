using Domain.Core.Interfaces;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs.Procedures
{
    public class General
    {
        private readonly ICoreRepository _coreRepository;

        public General(ICoreRepository coreRepository) =>
            _coreRepository = coreRepository;

        //public async Task P_Volo_Integracao_Pedidos([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Pedidos]");

        //    return;
        //}

        //public async Task P_Volo_Integracao_Infos_NFe([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Infos_NFe]");

        //    return;
        //}

        //public async Task P_Volo_Integracao_Infos_Pedidos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Infos_Pedidos]");

        //    return;
        //}
    }
}
