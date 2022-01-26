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

        public ObjectResult Details()
        {
            Employee model = this.employeeRepository.GetEmployee(1);

            return new ObjectResult(model);
        }

    }
}

