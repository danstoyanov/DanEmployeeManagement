using Microsoft.AspNetCore.Mvc;

using DanEmployeeManagement.Models;

namespace DanEmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = new MockEmployeeRepository();
        }

        public string Index() => employeeRepository.GetEmployee(1).Name;

        public ViewResult Details()
        {
            Employee employee = employeeRepository.GetEmployee(1);

            ViewBag.PageTitle = "Employee Details";

            return View(employee);
        }
    }
}

