using Application.Core.Middlewares;
using Dapper;
using Domain.Core.Interfaces;
using Microsoft.Azure.WebJobs;
using System.Data;

namespace AzureJobs.RecurringJobs.Procedures
{
    public class General
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly ICoreRepository _coreRepository;

        public General(ICoreRepository coreRepository) =>
            _coreRepository = coreRepository;

        //public async Task P_Volo_Integracao_Pedidos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        string sql = "SELECT DISTINCT EXECUTION FROM GENERAL.IT4_WMS_DOCUMENTO_CARGA";
        //        var executions = await _coreRepository.GetRecords<Guid>(sql);

        //        foreach (var execution in executions)
        //        {
        //            var parameters = new DynamicParameters();
        //            parameters.Add("@parentExecutionGUID", execution, DbType.Guid);

        //            var result = await _coreRepository.ExecuteCommand("[general].[p_Volo_Integracao_Pedidos]", parameters: parameters, commandType: CommandType.StoredProcedure);

        //            if (!result)
        //                continue;
        //        }

        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task p_Volo_Integracao_Pedidos_IntegrityLock([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[p_Volo_Integracao_Pedidos_IntegrityLock]");

        //    return;
        //}

        //public async Task P_Volo_Integracao_Infos_NFe([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Infos_NFe]");

        //    return;
        //}

        //public async Task P_Volo_Integracao_Infos_Pedidos([TimerTrigger("0 */5 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Infos_Pedidos]");

        //    return;
        //}

        //public async Task P_Volo_Integracao_Interface_Pedidos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[p_Volo_Integracao_Interfaces_Pedidos]");

        //    return;
        //}

        //public async Task P_Volo_Integracao_Fornecedores([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Fornecedores]");

        //    return;
        //}

        //public async Task P_Volo_Integracao_Produtos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Produtos]");

        //    return;
        //}

        //public async Task P_Volo_Integracao_Transportadoras([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Transportadoras]");

        //    return;
        //}

        //public async Task P_Volo_Integracao_Clientes([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Clientes]");

        //    return;
        //}

        //public async Task P_Server_Maintenance([TimerTrigger("0 6 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [dbo].[P_Server_Maintenance]");

        //    return;
        //}

        //public async Task p_JadLog_Insert_Unidade_Origem([TimerTrigger("0 6 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[p_InsertJadLogUnidadeOrigem]");

        //    return;
        //}

        //public async Task P_Volo_Integracao_Infos_Pedidos_Zpl([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    await _coreRepository.ExecuteCommand("exec [general].[p_Volo_Integracao_Infos_Pedidos_Zpl]");

        //    return;
        //}
    }
}
