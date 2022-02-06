using Microsoft.AspNetCore.Mvc;

using DanEmployeeManagement.Models;
using DanEmployeeManagement.ViewModels;

namespace DanEmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            var employees = employeeRepository.GetAllEmployee();

            return View(employees);
        }

        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new()
            {
                Employee = this.employeeRepository.GetEmployee(id),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var currEmployee = this.employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = employee.Id });
            }

            return View();
        }
    }
}

