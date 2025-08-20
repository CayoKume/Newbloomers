using Application.WebApi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("NewBloomers/BloomersInvoiceIntegrations/MiniWms")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService) =>
            _companyService = companyService;

        [HttpGet("GetCompanys")]
        public async Task<ActionResult<string>> GetCompanys()
        {
            try
            {
                var result = await _companyService.GetCompanys();

                if (string.IsNullOrEmpty(result))
                    return BadRequest($"Nao foi possivel encontrar as empresas no banco de dados.");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Nao foi possivel encontrar as empresas no banco de dados. Erro: {ex.Message}");
            }
        }
    }
}
