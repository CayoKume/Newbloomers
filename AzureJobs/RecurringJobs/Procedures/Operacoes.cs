using Application.IntegrationsCore.Middlewares;
using Domain.IntegrationsCore.Interfaces;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs.Procedures
{
    public class Operacoes
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;

        public Operacoes(IIntegrationsCoreRepository integrationsCoreRepository) =>
            _integrationsCoreRepository = integrationsCoreRepository;

        //public async Task P_Canal_Movimentacao_Periodo_Entrada([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Canal_Movimentacao_Periodo_Entrada]");

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Periodo_Ecommerce([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Canal_Movimentacao_Periodo_Ecommerce]");

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Periodo_Loja([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Canal_Movimentacao_Periodo_Loja]");

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Captado_Periodo_Entrada([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Entrada]");

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Captado_Periodo_Ecommerce([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Ecommerce]");

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Captado_Periodo_Loja([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Loja]");

        //    return;
        //}

        //public Task P_Snapshot_Estoque([TimerTrigger("57 23 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Snapshot_Estoque]");

        //    return Task.CompletedTask;
        //}
    }
}
