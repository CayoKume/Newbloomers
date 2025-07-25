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

        public Task P_Canal_Movimentacoes([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        {
            _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Canal_Movimentacoes]");

            return Task.CompletedTask;
        }

        //public Task P_Snapshot_Estoque([TimerTrigger("57 23 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Snapshot_Estoque]");

        //    return Task.CompletedTask;
        //}
    }
}
