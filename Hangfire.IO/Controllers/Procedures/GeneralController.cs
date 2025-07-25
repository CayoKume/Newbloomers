using Domain.IntegrationsCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Procedures
{
    public class GeneralController : Controller
    {
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;

        public GeneralController(IIntegrationsCoreRepository integrationsCoreRepository) =>
            (_integrationsCoreRepository) = (integrationsCoreRepository);

        [HttpPost("VoloIntegracaoPedidos")]
        public void P_Volo_Integracao_Pedidos()
        {
            var result = _integrationsCoreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Pedidos]");
        }

        [HttpPost("ManutencaoServidor")]
        public void P_Server_Maintenance()
        {
            var result = _integrationsCoreRepository.ExecuteCommand("exec [dbo].[P_Server_Maintenance]");
        }
    }
}
