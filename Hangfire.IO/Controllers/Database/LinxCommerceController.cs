using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Database
{
    public class LinxCommerceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
