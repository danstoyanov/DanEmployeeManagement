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
            this.employeeRepository = new MockEmployeeRepository();
        }

        public ViewResult Index()
        {
            var employees = employeeRepository.GetAllEmployee();

            return View(employees);
        }

        public ViewResult Details()
        {
            HomeDetailsViewModel homeDetailsViewModel = new()
            {
                Employee = this.employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }
    }
}

