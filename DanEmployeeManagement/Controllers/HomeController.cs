using Microsoft.AspNetCore.Mvc;

using DanEmployeeManagement.Models;

namespace DanEmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository employeeRepository;

        public HomeController()
        {
            this.employeeRepository = new MockEmployeeRepository();
        }

        public string Index() => employeeRepository.GetEmployee(1).Name;

    }
}

