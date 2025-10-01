using Application.Core.Middlewares;
using Dapper;
using Domain.Core.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace AzureJobs.RecurringJobs.Procedures
{
    public class Operacoes
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly ICoreRepository _coreRepository;

        public Operacoes(ICoreRepository coreRepository) =>
            _coreRepository = coreRepository;

        //public async Task P_Canal_Movimentacao_Periodo_Entrada([TimerTrigger("0 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Periodo_Entrada]");

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Periodo_Ecommerce([TimerTrigger("0 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Periodo_Ecommerce]");

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Periodo_Loja([TimerTrigger("0 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Periodo_Loja]");

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Captado_Periodo_Entrada([TimerTrigger("0 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Entrada]");

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Captado_Periodo_Ecommerce([TimerTrigger("0 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Ecommerce]");

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Captado_Periodo_Loja([TimerTrigger("0 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Loja]");

        //    return;
        //}

        //public async Task P_Snapshot_Estoque([TimerTrigger("57 23 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [operations].[P_Snapshot_Estoque]");

        //    return;
        //}
    }
}
