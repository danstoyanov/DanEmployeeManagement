using Microsoft.AspNetCore.Mvc;

namespace DanEmployeeManagement.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
