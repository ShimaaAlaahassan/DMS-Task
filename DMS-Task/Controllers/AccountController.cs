using Microsoft.AspNetCore.Mvc;

namespace DMS_Task.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
