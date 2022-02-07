﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

using DanEmployeeManagement.Models;
using DanEmployeeManagement.ViewModels;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;

namespace DanEmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(
            IEmployeeRepository employeeRepository,
            IHostingEnvironment hostingEnvironment)
        {
            this.employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
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
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.Photos != null && model.Photos.Count > 0)
                {
                    foreach (IFormFile photo in model.Photos)
                    {
                        string uploadsFolder = Path.Combine(this.hostingEnvironment.WebRootPath, "images");

                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }


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
    }
}

