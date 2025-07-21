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
        public void CanalMovimentacao()
        {
            _integrationsCoreRepository.CallDbProcMerge("operations", "[p_Canal_Movimentacoes]");
        }
    }
}
