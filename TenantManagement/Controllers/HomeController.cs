using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
