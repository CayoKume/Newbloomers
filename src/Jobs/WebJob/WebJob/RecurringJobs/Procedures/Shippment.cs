using Application.Core.Middlewares;
using Domain.Core.Interfaces;
using Microsoft.Azure.WebJobs;

namespace WebJob.RecurringJobs.Procedures
{
    public class Shippment
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly ICoreRepository _coreRepository;

        public Shippment(ICoreRepository coreRepository) =>
            _coreRepository = coreRepository;

        //public async Task p_InsertJadLogUnidadeOrigem([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[p_InsertJadLogUnidadeOrigem]");

        //    return;
        //}

        //public async Task P_JadLogInsertCodigoShipmentId([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_JadLogInsertCodigoShipmentId]");

        //    return;
        //}
    }
}
