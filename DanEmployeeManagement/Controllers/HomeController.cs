using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

using DanEmployeeManagement.Models;
using DanEmployeeManagement.ViewModels;

namespace DanEmployeeManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;

        public HomeController(
            IEmployeeRepository employeeRepository,
            IHostingEnvironment hostingEnvironment,
            ILogger<HomeController> logger)
        {
            this.employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var employees = employeeRepository.GetAllEmployee();

            return View(employees);
        }

        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
            //   throw new Exception("Error in Detaisls View");

            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Crititcal Log");

            var employee = this.employeeRepository.GetEmployee(id.Value);

            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            var homeDetailsViewModel = new HomeDetailsViewModel
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var employee = this.employeeRepository.GetEmployee(id);

            var employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };

            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = this.employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;

                if (model.Photos != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        var filePath = Path.Combine(
                            hostingEnvironment.WebRootPath,
                            "images",
                            model.ExistingPhotoPath);

                        System.IO.File.Delete(filePath);
                    }

                    employee.PhotoPath = ProccesUploadedFile(model);
                }

                this.employeeRepository.Update(employee);

                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProccesUploadedFile(model);

                var newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                this.employeeRepository.Add(newEmployee);

                return RedirectToAction("details", new { id = newEmployee.Id });
            }

            return View();
        }

        private string ProccesUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile photo in model.Photos)
                {
                    string uploadsFolder = Path.Combine(this.hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }
    }
}

