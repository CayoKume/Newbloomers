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
        private static int contador = 0;
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly ICoreRepository _coreRepository;

        public Operacoes(ICoreRepository coreRepository) =>
            _coreRepository = coreRepository;

        //public async Task P_Canal_Movimentacao_Periodo_Entrada([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var parameters = new DynamicParameters();

        //    if (contador <= 10)
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 1);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Periodo_Entrada]", parameters: parameters);
        //        contador++;
        //    }
        //    else
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 7);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Periodo_Entrada]", parameters: parameters);
        //        contador = 0;
        //    }

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Periodo_Ecommerce([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var parameters = new DynamicParameters();

        //    if (contador <= 10)
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 1);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Periodo_Ecommerce]", parameters: parameters);
        //        contador++;
        //    }
        //    else
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 7);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Periodo_Ecommerce]", parameters: parameters);
        //        contador = 0;
        //    }

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Periodo_Loja([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var parameters = new DynamicParameters();

        //    if (contador <= 10)
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 1);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Periodo_Loja]", parameters: parameters);
        //        contador++;
        //    }
        //    else
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 7);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Periodo_Loja]", parameters: parameters);
        //        contador = 0;
        //    }

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Captado_Periodo_Entrada([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var parameters = new DynamicParameters();

        //    if (contador <= 10)
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 1);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Entrada]", parameters: parameters);
        //        contador++;
        //    }
        //    else
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 7);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Entrada]", parameters: parameters);
        //        contador = 0;
        //    }

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Captado_Periodo_Ecommerce([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var parameters = new DynamicParameters();

        //    if (contador <= 10)
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 1);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Ecommerce]", parameters: parameters);
        //        contador++;
        //    }
        //    else
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 7);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Ecommerce]", parameters: parameters);
        //        contador = 0;
        //    }

        //    return;
        //}

        //public async Task P_Canal_Movimentacao_Captado_Periodo_Loja([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    var parameters = new DynamicParameters();

        //    if (contador <= 10)
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 1);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Loja]", parameters: parameters);
        //        contador++;
        //    }
        //    else
        //    {
        //        parameters.Add("@QTD_DIAS_RETROATIVOS", 7);
        //        var result = await _coreRepository.ExecuteCommand($"exec [operations].[P_Canal_Movimentacao_Captado_Periodo_Loja]", parameters: parameters);
        //        contador = 0;
        //    }

        //    return;
        //}

        //public Task P_Snapshot_Estoque([TimerTrigger("57 23 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    _coreRepository.ExecuteCommand("exec [operations].[P_Snapshot_Estoque]");

        //    return Task.CompletedTask;
        //}
    }
}
