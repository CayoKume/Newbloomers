using Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Procedures
{
    public class GeneralController : Controller
    {
        private readonly ICoreRepository _coreRepository;

        public GeneralController(ICoreRepository coreRepository) =>
            (_coreRepository) = (coreRepository);

        [HttpPost("VoloIntegracaoPedidos")]
        public void P_Volo_Integracao_Pedidos()
        {
            var result = _coreRepository.ExecuteCommand("exec [general].[P_Volo_Integracao_Pedidos]");
        }

        [HttpPost("ManutencaoServidor")]
        public void P_Server_Maintenance()
        {
            var result = _coreRepository.ExecuteCommand("exec [dbo].[P_Server_Maintenance]");
        }
    }
}
