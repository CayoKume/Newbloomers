using Application.Core.Middlewares;
using Domain.Core.Interfaces;
using Microsoft.Azure.WebJobs;

namespace WebJob.RecurringJobs.Procedures
{
    public class LinxMicrovix
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly ICoreRepository _coreRepository;

        public LinxMicrovix(ICoreRepository coreRepository) =>
            _coreRepository = coreRepository;

        //public async Task p_Insert_Missing_LinxProdutosDetalhes([TimerTrigger("0 6 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [linx_microvix_erp].[p_InsertMissingLinxProdutosDetalhes]");

        //    return;
        //}

        //public async Task P_Insert_Missing_LinxProdutosInventario([TimerTrigger("0 6 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [linx_microvix_erp].[p_InsertMissingLinxProdutosInventario]");

        //    return;
        //}
    }
}
