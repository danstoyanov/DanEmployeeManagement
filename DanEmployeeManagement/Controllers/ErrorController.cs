using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace DanEmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resourse you requested could not be found";
                    break;
            }

            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exeptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exeptionDetails.Path;
            ViewBag.ExeptionMessage = exeptionDetails.Error.Message;
            ViewBag.Stacktrace = exeptionDetails.Error.StackTrace;

            return View("Error");
        }
    }
}
