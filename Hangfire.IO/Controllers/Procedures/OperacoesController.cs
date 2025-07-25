using Domain.IntegrationsCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Procedures
{
    public class OperacoesController : Controller
    {
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;

        public OperacoesController(IIntegrationsCoreRepository integrationsCoreRepository) =>
            (_integrationsCoreRepository) = (integrationsCoreRepository);

        [HttpPost("CanalMovimentacao")]
        public void P_Canal_Movimentacoes()
        {
            var result = _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Canal_Movimentacoes]");
        }

        [HttpPost("SnapshotEstoque")]
        public void P_Snapshot_Estoque()
        {
            var result = _integrationsCoreRepository.ExecuteCommand("exec [operations].[P_Snapshot_Estoque]");
        }
    }
}
