using Domain.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Procedures
{
    [ApiController]
    [Authorize]
#if RELEASE
    [ApiExplorerSettings(IgnoreApi = true)]
#endif
    [Route("ProceduresJobs/Operacoes")]
    public class OperacoesController : Controller
    {
        private readonly ICoreRepository _coreRepository;

        public OperacoesController(ICoreRepository coreRepository) =>
            (_coreRepository) = (coreRepository);

        [HttpPost("CanalMovimentacao")]
        public void P_Canal_Movimentacoes()
        {
            var result = _coreRepository.ExecuteCommand("exec [operations].[P_Canal_Movimentacoes]");
        }

        [HttpPost("SnapshotEstoque")]
        public void P_Snapshot_Estoque()
        {
            var result = _coreRepository.ExecuteCommand("exec [operations].[P_Snapshot_Estoque]");
        }
    } 
}
