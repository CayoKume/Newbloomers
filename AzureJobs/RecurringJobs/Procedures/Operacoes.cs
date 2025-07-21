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

        //public async Task AfterSaleEcommerces([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var result = _integrationsCoreRepository.CallDbProcMerge();
        //}
    }
}
