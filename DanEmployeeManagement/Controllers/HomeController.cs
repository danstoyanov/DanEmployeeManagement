using Microsoft.AspNetCore.Mvc;

namespace DanEmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index() => Json(new { id = 1, name = "Pelicanko" });
    }
}
