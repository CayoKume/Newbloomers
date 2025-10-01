using Dapper;
using Domain.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hangfire.IO.Controllers.Procedures
{
    [ApiController]
    [Authorize]
#if RELEASE
    [ApiExplorerSettings(IgnoreApi = true)]
#endif
    [Route("ProceduresJobs/Operacoes")]
    public class GeneralController : Controller
    {
        private readonly ICoreRepository _coreRepository;

        public GeneralController(ICoreRepository coreRepository) =>
            (_coreRepository) = (coreRepository);

        [HttpPost("ManutencaoServidor")]
        public void P_Server_Maintenance()
        {
            var result = _coreRepository.ExecuteCommand("exec [dbo].[P_Server_Maintenance]");
        }

        [HttpPost("P_Volo_Integracao_Pedidos")]
        public async Task P_Volo_Integracao_Pedidos()
        {
            try
            {
                string sql = "SELECT DISTINCT EXECUTION FROM GENERAL.IT4_WMS_DOCUMENTO_CARGA";
                var executions = await _coreRepository.GetRecords<Guid>(sql);

                foreach (var execution in executions)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@parentExecutionGUID", execution, DbType.Guid);

                    var result = await _coreRepository.ExecuteCommand("[general].[p_Volo_Integracao_Pedidos]", parameters: parameters, commandType: CommandType.StoredProcedure);

                    if (!result)
                        continue;
                }

                return;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    } 
}
