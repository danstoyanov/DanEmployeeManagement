using Microsoft.AspNetCore.Mvc;

using DanEmployeeManagement.Models;
using DanEmployeeManagement.ViewModels;

namespace DanEmployeeManagement.Controllers
{
    [Route("Home")]
    public class WellcomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public WellcomeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = new MockEmployeeRepository();
        }

        [Route("")]
        [Route("Index")]
        [Route("~/")]
        public ViewResult Index()
        {
            var employees = employeeRepository.GetAllEmployee();

            return View("~/Views/Home/index.cshtml", employees);
        }

        [Route("Details/{id=1}")]
        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new()
            {
                Employee = this.employeeRepository.GetEmployee(id),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }
    }
}

